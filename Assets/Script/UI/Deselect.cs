using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deselect : MonoBehaviour
{
	public bool canActivate = false;

	public void Delete ()
	{
		canActivate = true;
		Destroy (gameObject.transform.parent.gameObject);
	}
}
