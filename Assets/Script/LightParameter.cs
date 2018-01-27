using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightParameter : MonoBehaviour
{

	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.CompareTag ("Color"))
		{
			GameObject gb = Instantiate (gameObject);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			TrailRenderer t = gb.GetComponent<TrailRenderer> ();
			t.startColor = Color.red;
			t.endColor = Color.red;
			collision.enabled = false;
			Debug.Log ("Color Changed");
		}
	}
}
