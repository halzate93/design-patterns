using UnityEngine;
using System.Collections;

namespace Patterns
{
	[RequireComponent (typeof (MainWeapon))]
	public class WeaponUser : MonoBehaviour 
	{
		private MainWeapon weapon;

		private void Awake ()
		{
			weapon = GetComponent <MainWeapon> ();
		}

		private void Update ()
		{
			if (Input.GetMouseButtonDown (0))
				weapon.Shoot ();

			if (Input.GetKeyDown (KeyCode.Space))
				weapon.AddPowerUp ();
		}
	}
}