using UnityEngine;
using System.Collections;

namespace Patterns
{
	public class CarClient : MonoBehaviour {

		[SerializeField]
		private CarFactory factory;

		private GameObject lastCar;

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Space))
				GetNewCar ();
		}

		private void GetNewCar ()
		{
			if (lastCar != null)
				Destroy (lastCar);
			lastCar = factory.BuildCar ();
			lastCar.transform.position = transform.position;
		}
	}
}