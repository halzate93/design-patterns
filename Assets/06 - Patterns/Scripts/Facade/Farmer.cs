using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class Farmer : MonoBehaviour {

		[SerializeField]
		private float efficiency;

		public int Milk (Cow cow)
		{
			return (int) (cow.GetMilk () * efficiency);
		}
	}
}