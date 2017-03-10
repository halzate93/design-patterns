using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class ClickNotifier : MonoBehaviour 
	{
		private void Update ()
		{
			if (Input.GetMouseButtonDown (0))
				GameManager.Instance.NotifyHit ();
		}
	}
}
