using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightParameter : MonoBehaviour
{

	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.CompareTag ("ColorChange"))
		{
			GameObject gb = Instantiate (gameObject);
			//GetComponent<LightMovement> ().direction = Vector2.zero;
			TrailRenderer t = gb.GetComponent<TrailRenderer> ();
			t.startColor = collision.GetComponent<SpriteRenderer> ().color;
			t.endColor = collision.GetComponent<SpriteRenderer> ().color;
			collision.enabled = false;
			Debug.Log ("Color Changed");
		}

		else if (collision.CompareTag ("ColorBlock"))
		{
			if (collision.GetComponent<SpriteRenderer> ().color != GetComponent<TrailRenderer> ().startColor)
			{
				GetComponent<LightMovement> ().direction = Vector2.zero;
			}
		}
	}
}
