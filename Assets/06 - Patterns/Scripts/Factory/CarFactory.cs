using UnityEngine;

namespace Patterns
{
	public class CarFactory : MonoBehaviour {

		[SerializeField]
		private GameObject carTemplate;

		public GameObject BuildCar ()
		{
			GameObject instance = Instantiate (carTemplate);
			ApplyColor (instance);
			return instance;
		}

		private void ApplyColor (GameObject car)
		{
			Renderer carRenderer = car.GetComponent <Renderer> ();
			carRenderer.material.color = GetRandomColor ();
		}

		private Color GetRandomColor()
		{
			float r = Random.Range (0f, 1f);
			float g = Random.Range (0f, 1f);
			float b = Random.Range (0f, 1f);
			Color color = new Color (r, g, b, 1f);
			return color;
		}
	}
}