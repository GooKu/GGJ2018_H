using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.CompareTag ("Player"))
		{
			Debug.Log ("Stage Clear!");
			collision.gameObject.GetComponent<LightMovement> ().direction = Vector2.zero;
		}
	}
}
