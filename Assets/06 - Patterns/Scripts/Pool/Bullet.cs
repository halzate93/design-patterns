using UnityEngine;
using System.Collections;

namespace Patterns
{
	[RequireComponent (typeof (Rigidbody))]
	public class Bullet : MonoBehaviour {

		private Rigidbody rigidbody;

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