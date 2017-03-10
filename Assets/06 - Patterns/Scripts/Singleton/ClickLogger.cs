using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class ClickLogger : MonoBehaviour {

		private void Start () 
		{
			GameManager.Instance.OnHit += DebugHit;
		}

		private void DebugHit ()
		{
			Debug.Log ("Hit");
		}
	}
}