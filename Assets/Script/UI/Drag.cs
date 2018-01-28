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

	private GameObject scrollView, nextItem, preItem;
	private GameObject gb;
	private Slider f;
	private Slider s;
	private Slider r;
	private Button d;

	private void Awake ()
	{
		scrollView = GameObject.Find ("Scroll View");
		nextItem = GameObject.Find ("NextItem");
		preItem = GameObject.Find ("PreItem");
	}

	private void OnMouseDrag ()
	{
		Debug.Log ("Drag");
		Vector3 pos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		Vector3 objpos = Camera.main.ScreenToWorldPoint (pos);
		transform.position = objpos;
	}

	private void OnMouseDown ()
	{
		Debug.Log ("HI");

		if (gameObject.tag == "Mirror")
		{
			if (gb == null)
				spawnModifier ();

			s = Instantiate (scale, GameObject.Find ("Modifier").transform);
			s.GetComponent<Modify> ().gb = gameObject;
			s.transform.localPosition = new Vector3 (-370, 15, 0);
			s.name = "Scale";

			r = Instantiate (rotate, GameObject.Find ("Modifier").transform);
			r.GetComponent<Modify> ().gb = gameObject;
			r.transform.localPosition = new Vector3 (-125, 15, 0);
			r.name = "Rotate";

			d = Instantiate (deselect, GameObject.Find ("Modifier").transform);
			d.transform.localPosition = new Vector3 (0, 50, 0);
			d.name = "Deselect";
		}

		else if (gameObject.tag == "Black Hole")
		{
			if (gb == null)
				spawnModifier ();

			f = Instantiate (force, GameObject.Find ("Modifier").transform);
			f.GetComponent<Modify> ().gb = gameObject;
			f.transform.localPosition = new Vector3 (-190, 15, 0);
			f.name = "Force";

			d = Instantiate (deselect, GameObject.Find ("Modifier").transform);
			d.transform.localPosition = new Vector3 (0, 50, 0);
			d.name = "Deselect";
		}

		if (GameObject.Find ("Modifier"))
		{
			Debug.Log ("find");
			activate (false);
			return;
		}
	}

	public void Update ()
	{
		if (GameObject.Find ("Deselect") && GameObject.Find ("Deselect").GetComponent<Deselect> ().canActivate)
			activate (true);
	}

	public void spawnModifier ()
	{
		gb = Instantiate (modifier, GameObject.Find ("UI").transform);
		gb.name = "Modifier";
		gb.transform.localPosition = new Vector3 (0, -330, 0);
	}

	private void activate (bool boo)
	{
		scrollView.SetActive (boo);
		nextItem.SetActive (boo);
		preItem.SetActive (boo);
	}
}