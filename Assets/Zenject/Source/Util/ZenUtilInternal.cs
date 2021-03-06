using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ModestTree.Util;

#if !NOT_UNITY3D
using UnityEngine.SceneManagement;
using UnityEngine;
#endif

namespace Zenject.Internal
{
    public class ZenUtilInternal
    {
        // Due to the way that Unity overrides the Equals operator,
        // normal null checks such as (x == null) do not always work as
        // expected
        // In those cases you can use this function which will also
        // work with non-unity objects
        public static bool IsNull(System.Object obj)
        {
            return obj == null || obj.Equals(null);
        }

        // This can be useful if you are running code outside unity
        // since in that case you have to make sure to avoid calling anything
        // inside Unity DLLs
        public static bool IsOutsideUnity()
        {
            return AppDomain.CurrentDomain.FriendlyName != "Unity Child Domain";
        }

        public static bool AreFunctionsEqual(Delegate left, Delegate right)
        {
            return left.Target == right.Target && left.Method() == right.Method();
        }

#if !NOT_UNITY3D
        public static IEnumerable<SceneContext> GetAllSceneContexts()
        {
            foreach (var scene in UnityUtil.AllLoadedScenes)
            {
                var contexts = scene.GetRootGameObjects()
                    .SelectMany(root => root.GetComponentsInChildren<SceneContext>()).ToList();

                if (contexts.IsEmpty())
                {
                    continue;
                }

                Assert.That(contexts.Count == 1,
                    "Found multiple scene contexts in scene '{0}'", scene.name);

                yield return contexts[0];
            }
        }

        // NOTE: This method will not return components that are within a GameObjectContext
        public static List<MonoBehaviour> GetInjectableMonoBehaviours(GameObject gameObject)
        {
            var childMonoBehaviours = gameObject.GetComponentsInChildren<MonoBehaviour>(true);

            var subContexts = childMonoBehaviours.OfType<GameObjectContext>().Select(x => x.transform).ToList();

            return childMonoBehaviours.Where(x =>
                    // Can be null for broken component references
                    x != null
                    // Do not inject on installers since these are always injected before they are installed
                    && !x.GetType().DerivesFrom<MonoInstaller>()
                    // Need to make sure we don't inject on any MonoBehaviour's that are below a GameObjectContext
                    // Since that is the responsibility of the GameObjectContext
                    // BUT we do want to inject on the GameObjectContext itself
                    && UnityUtil.GetParents(x.transform).Intersect(subContexts).IsEmpty()
                    && (x.GetComponent<GameObjectContext>() == null || x is GameObjectContext))
                .OrderByDescending(x => GetParentCount(x.transform))
                .ToList();
        }

        static int GetParentCount(Transform transform)
        {
            int result = 0;

            while (transform.parent != null)
            {
                transform = transform.parent;
                result++;
            }

            return result;
        }

        public static IEnumerable<MonoBehaviour> GetInjectableMonoBehaviours(Scene scene)
        {
            return GetRootGameObjects(scene)
                .SelectMany<GameObject, MonoBehaviour>(ZenUtilInternal.GetInjectableMonoBehaviours);
        }

        public static IEnumerable<GameObject> GetRootGameObjects(Scene scene)
        {
            if (scene.isLoaded)
            {
                return scene.GetRootGameObjects()
                    .Where(x => x.GetComponent<ProjectContext>() == null);
            }

            // Note: We can't use scene.GetRootObjects() here because that apparently fails with an exception
            // about the scene not being loaded yet when executed in Awake
            // We also can't use GameObject.FindObjectsOfType<Transform>() because that does not include inactive game objects
            // So we use Resources.FindObjectsOfTypeAll, even though that may include prefabs.  However, our assumption here
            // is that prefabs do not have their "scene" property set correctly so this should work
            //
            // It's important here that we only inject into root objects that are part of our scene, to properly support
            // multi-scene editing features of Unity 5.x
            //
            // Also, even with older Unity versions, if there is an object that is marked with DontDestroyOnLoad, then it will
            // be injected multiple times when another scene is loaded
            //
            // We also make sure not to inject into the project root objects which are injected by ProjectContext.
            return Resources.FindObjectsOfTypeAll<GameObject>()
                .Where(x => x.transform.parent == null
                    && x.GetComponent<ProjectContext>() == null
                    && x.scene == scene);
        }
#endif
    }
}
