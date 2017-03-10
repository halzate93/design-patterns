using UnityEngine;
using System.Collections;

namespace Patterns
{
	public abstract class PowerUp : MonoBehaviour, IWeapon{

		public int Ammo {
			get;
			set;
		}

		public bool HasAmmo
		{
			get
			{ 
				return Ammo > 0;
			}
		}

		public void Shoot ()
		{
			if (HasAmmo) {
				ShootPowerUp ();
				Ammo--;
			}
		}

		protected abstract void ShootPowerUp ();
	}
}