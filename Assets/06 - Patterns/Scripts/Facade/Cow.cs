using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class Cow : MonoBehaviour {

		[SerializeField]
		private float maxMilk;

		[SerializeField]
		private float generatedMilkPerSecond;

		private float milk;

		private void Update ()
		{
			if (milk < maxMilk)
				milk = Mathf.Clamp(milk + generatedMilkPerSecond * Time.deltaTime, 0, maxMilk);
		}

		public float GetMilk ()
		{
			float shippedMilk = milk;
			milk = 0f;
			return shippedMilk;
		}
	}
}