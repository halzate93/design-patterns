using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class CommandedCharacter : MonoBehaviour {

		public void Move(int x, int y)
		{
			Debug.Log (string.Format ("Moving to x: {0}, y: {1}", x, y));
		}

		public void Attack ()
		{
			Debug.Log ("Attacking");
		}
	}
}
