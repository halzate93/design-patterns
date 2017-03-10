using UnityEngine;

namespace Patterns
{
	[RequireComponent (typeof (Rigidbody))]
	public class Bullet : MonoBehaviour {

		private new Rigidbody rigidbody;

		private void Awake () 
		{
			rigidbody = GetComponent <Rigidbody> ();		
		}

		private void OnCollisionEnter (Collision collision)
		{
			BulletPool.Instance.ReleaseBullet (rigidbody);
		}
	}
}