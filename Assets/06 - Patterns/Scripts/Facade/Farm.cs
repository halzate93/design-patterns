using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class Farm : MonoBehaviour {

		private static Farm instance;

		[SerializeField]
		private Farmer farmer;

		[SerializeField]
		private Cow cow;

		public static Farm Instance
		{
			get
			{ 
				return instance;
			}
		}

		private void Awake ()
		{
			if (instance == null)
				instance = this;
			else
				Destroy (gameObject);
		}

		public int GetMilk ()
		{
			return farmer.Milk (cow);
		}
	}
}