using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
	public Slider scale;
	public Slider rotate;
	public Slider force;
	public Button deselect;
	public GameObject modifier;

	private GameObject gb;
	private Slider f;
	private Slider s;
	private Slider r;
	private Button d;

	private void OnMouseDrag ()
	{
		Vector3 pos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		Vector3 objpos = Camera.main.ScreenToWorldPoint (pos);
		transform.position = objpos;
	}

	private void OnMouseDown ()
	{
		if (GameObject.Find ("Modifier"))
		{
			/*if (GameObject.Find ("Modifier").activeSelf == true)
				return;
			else
				GameObject.Find ("Modifier").SetActive (true);*/
			return;
		}
			

		if (gameObject.tag == "Mirror")
		{
			if (gb == null)
			{
				gb = Instantiate (modifier, GameObject.Find ("UI").transform);
				gb.name = "Modifier";
			}

			s = Instantiate (scale, GameObject.Find ("Modifier").transform);
			s.GetComponent<Modify> ().gb = gameObject;
			s.name = "Scale";

			r = Instantiate (rotate, GameObject.Find ("Modifier").transform);
			r.GetComponent<Modify> ().gb = gameObject;
			r.name = "Rotate";

			d = Instantiate (deselect, GameObject.Find ("Modifier").transform);
			d.name = "Deselect";
		}

		else if (gameObject.tag == "Black Hole")
		{
			if (gb == null)
			{
				gb = Instantiate (modifier, GameObject.Find ("UI").transform);
				gb.name = "Modifier";
			}

			f = Instantiate (force, GameObject.Find ("Modifier").transform);
			f.GetComponent<Modify> ().gb = gameObject;
			f.name = "Force";

			d = Instantiate (deselect, GameObject.Find ("Modifier").transform);
			d.name = "Deselect";
		}
	}
}