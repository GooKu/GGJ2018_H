using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deselect : MonoBehaviour
{
	public GameObject gb;

	public void Delete ()
	{
		//gameObject.transform.parent.gameObject.SetActive (false);
		Destroy (gameObject.transform.parent.gameObject);
	}
}
