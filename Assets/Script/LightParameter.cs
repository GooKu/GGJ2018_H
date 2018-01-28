using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightParameter : MonoBehaviour
{

	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.CompareTag ("ColorChange"))
		{
			if (SceneManager.GetActiveScene ().name == "Level2")
			{
				GetComponent<TrailRenderer> ().startColor = collision.GetComponent<SpriteRenderer> ().color;
				GetComponent<TrailRenderer> ().endColor = collision.GetComponent<SpriteRenderer> ().color;
			}

			else
			{
				GameObject gb = Instantiate (gameObject);
				GetComponent<LightMovement> ().direction = Vector2.zero;
				TrailRenderer t = gb.GetComponent<TrailRenderer> ();
				t.startColor = collision.GetComponent<SpriteRenderer> ().color;
				t.endColor = collision.GetComponent<SpriteRenderer> ().color;
				collision.enabled = false;
//				Debug.Log ("Color Changed");
                GetComponent<LightMovement>().Stop();
            }

		}

		else if (collision.CompareTag ("ColorBlock"))
		{
//			Debug.Log (collision.GetComponent<SpriteRenderer> ().color + ", " + GetComponent<TrailRenderer> ().startColor);
			if (collision.GetComponent<SpriteRenderer> ().color != GetComponent<TrailRenderer> ().startColor)
			{
				GetComponent<LightMovement> ().Stop();
			}
		}
	}
}
