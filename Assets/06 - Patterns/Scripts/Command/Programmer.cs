using UnityEngine;
using System.Collections.Generic;

namespace Patterns
{
	public class Programmer : MonoBehaviour {

		private List<IAction> actions;

		[SerializeField]
		private CommandedCharacter character;

		private void Awake ()
		{
			actions = new List<IAction> ();
		}

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Space))
				ExecuteActions ();
			else if (Input.GetKeyDown (KeyCode.A))
				actions.Add (new Attack ());
			else if (Input.GetKeyDown (KeyCode.M)) {
				int x = Random.Range (0, 10);
				int y = Random.Range (0, 10);
				actions.Add (new Move (x, y));
			}
		}

		private void ExecuteActions ()
		{
			foreach (IAction action in actions) {
				action.Execute (character);
			}
			actions.Clear ();
		}
	}
}