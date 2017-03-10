using UnityEngine;
using System.Collections;

namespace Patterns
{
	public interface IWeapon {
		bool HasAmmo {
			get;
		}
		void Shoot ();
	}
}