using UnityEngine;
using System.Collections.Generic;

namespace Patterns
{
	public class MainWeapon: MonoBehaviour, IWeapon
	{
		public bool HasAmmo
		{
			get
			{ 
				return true;
			}
		}

		[SerializeField]
		private float force;

		private List<PowerUp> weapons;

		private void Awake ()
		{
			weapons = new List<PowerUp> ();
		}

		public void Shoot ()
		{
			SpawnBullet ();
			List<PowerUp> toRemove = new List<PowerUp> ();
			foreach (PowerUp decorator in weapons) {
				decorator.Shoot ();
				if (!decorator.HasAmmo)
				{
					toRemove.Add (decorator);
					Destroy (decorator);
				}
			}

			foreach (PowerUp removed in toRemove) 
			{
				weapons.Remove (removed);
			}
		}

		private void SpawnBullet ()
		{
			Rigidbody bullet = BulletPool.Instance.GetBullet ();
			bullet.transform.position = transform.position;
			bullet.AddForce (transform.forward * force);
		}

		public void AddPowerUp ()
		{
			if (weapons.Find ((powerUp) => powerUp is Turret) == null) {
				PowerUp toAdd = gameObject.AddComponent <Turret> ();
				weapons.Add (toAdd);
				toAdd.Ammo = 3;
			}
		}
	}
}