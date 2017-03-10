using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class MilkUser : MonoBehaviour {
		private void Update () {
			if (Input.GetKeyDown (KeyCode.Space))
				Debug.Log (Farm.Instance.GetMilk ());				
		}
	}
}