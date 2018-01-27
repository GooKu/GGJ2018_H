using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.CompareTag ("Player"))
		{
			collision.gameObject.GetComponent<LightMovement> ().direction = Vector2.zero;
			collision.gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;

			if (gameObject.tag == "Sensor")
			{
				GameObject.Find ("Block").GetComponent<Block> ().triggered++;
				Debug.Log ("sensor");
			}

			if (gameObject.name == "Exit")
				Debug.Log ("Stage Clear!");
		}
	}
}
