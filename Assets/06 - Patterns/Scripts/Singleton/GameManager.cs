using UnityEngine;
using System;
using System.Collections;

namespace Patterns
{
	public class GameManager : MonoBehaviour 
	{
		private static GameManager instance;

		public static GameManager Instance
		{
			get
			{ 
				return instance;
			}
		}

		public event Action OnHit;

		private int score;

		public int Score
		{
			get
			{ 
				return score;
			}
		}

		private void Awake ()
		{
			if (instance != null)
				Destroy (gameObject);
			else
				instance = this;
		}

		public void NotifyHit ()
		{
			score++;
			if (OnHit != null)
				OnHit ();
		}
	}
}