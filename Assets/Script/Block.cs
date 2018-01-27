using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public int triggered;
	public int needed;

	private void Awake ()
	{
		triggered = 0;
	}

	private void Update ()
	{
		if (triggered >= needed)
			Destroy (gameObject);
	}

	private void OnTriggerEnter2D (Collider2D collision)
	{
		Destroy (collision.gameObject);
		Debug.Log ("You Died!");
	}
}
