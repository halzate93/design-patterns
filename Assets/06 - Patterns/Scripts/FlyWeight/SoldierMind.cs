using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class SoldierMind : MonoBehaviour {

		public void UpdateSoldier (Soldier soldier)
		{
			//TODO  doSomething
			int option = Random.Range (0, 2);

			switch (option) {
			case 0: 
				soldier.Attack ();
				break;
			case 1:
				soldier.Run ();
				break;
			default:
				break;
			}
		}
	}
}