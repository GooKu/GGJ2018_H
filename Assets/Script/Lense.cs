using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lense : MonoBehaviour
{
	private bool isSplitting = false;
	[SerializeField]
	private int splitNumber;

	private void OnTriggerExit2D (Collider2D collision)
	{
		if (isSplitting) return;
		isSplitting = true;
		float angle = 0f;
		List<GameObject> newLights = new List<GameObject> ();
		angle = 180 / (splitNumber + 1);
		for (int i = 0; i < splitNumber; i++)
		{
			newLights.Add (Instantiate (collision.gameObject));
			float newAngle = angle * (i + 1);
			float rad = newAngle * Mathf.Deg2Rad;
			if (collision.transform.rotation.z == 0 || collision.transform.rotation.z == 180)
				newLights [i].GetComponent<LightMovement> ().direction =
					(new Vector2 (Mathf.Sin (rad), Mathf.Cos (rad))).normalized;
			else
				newLights [i].GetComponent<LightMovement> ().direction =
					(new Vector2 (Mathf.Cos (rad), Mathf.Sin (rad))).normalized;
		}
		Destroy (collision.gameObject);
		StartCoroutine (ExecuteAfterTime (1));
	}

	IEnumerator ExecuteAfterTime (float time)
	{
		yield return new WaitForSeconds (time);
		isSplitting = false;
	}



	private void Start ()
	{
		if (splitNumber < 2)
		{
			splitNumber = 2;
		}
	}

	public int getNumber ()
	{
		return splitNumber;
	}

}