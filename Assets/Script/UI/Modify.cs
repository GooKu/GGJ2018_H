using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modify : MonoBehaviour
{
	public GameObject gb;
	private Slider slider;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider> ();
		if (slider.name == "Scale")
			slider.value = gb.transform.localScale.x;
		else if (slider.name == "Rotate")
			slider.value = gb.transform.eulerAngles.z;
		else if (slider.name == "Force")
			slider.value = gb.GetComponent<BlackHole> ().force;
	}

	public void Scale ()
	{
		float change = slider.value;
		gb.transform.localScale = new Vector3 (change, gb.transform.localScale.y, gb.transform.localScale.z);
	}

	public void Rotate ()
	{
		float change = slider.value;
		gb.transform.eulerAngles = new Vector3 (0, 0, change);
		Debug.Log (change);
	}

	public void Force ()
	{
		float change = slider.value;
		gb.GetComponent<BlackHole> ().force = change;
	}
}
