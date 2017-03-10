using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class Turret : PowerUp {
		protected override void ShootPowerUp ()
		{
			//TODO: ShootTurret
			Debug.Log ("Turret Power up");
		}
	}
}