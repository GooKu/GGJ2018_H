using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scene : MonoBehaviour
{
    public Action OnArrived = delegate () { };

	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.CompareTag ("Player"))
		{
			collision.gameObject.GetComponent<LightMovement> ().Stop();

			if (gameObject.tag == "Sensor")
			{
				GameObject.Find ("Block").GetComponent<Block> ().triggered++;
				Debug.Log ("sensor");
			}

			if (gameObject.name == "Exit")
            {
                Debug.Log("Stage Clear!");
                OnArrived();
            }
		}
	}
}
