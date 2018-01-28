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
	public GameObject scrollView;
	public GameObject nextItem;
	public GameObject preItem;

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
		Vector3 pos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		Vector3 objpos = Camera.main.ScreenToWorldPoint (pos);
		transform.position = objpos;
	}

	private void OnMouseDown ()
	{
		if (GameObject.Find ("Modifier"))
			return;
			
		if (gameObject.tag == "Mirror")
		{
			if (gb == null)
				spawnModifier ();
			else return;

			activate (false);

			s = Instantiate (scale, GameObject.Find ("Modifier").transform);
			s.GetComponent<Modify> ().gb = gameObject;
			s.transform.localPosition = new Vector3 (-372, 15, 0);
			s.name = "Scale";

			r = Instantiate (rotate, GameObject.Find ("Modifier").transform);
			r.GetComponent<Modify> ().gb = gameObject;
			r.transform.localPosition = new Vector3 (-128, 15, 0);
			r.name = "Rotate";

			d = Instantiate (deselect, GameObject.Find ("Modifier").transform);
			d.name = "Deselect";
			d.transform.localPosition = new Vector3 (0, 50, 0);
		}

		else if (gameObject.tag == "Black Hole")
		{
			if (gb == null)
				spawnModifier ();
			else
				return;

			f = Instantiate (force, GameObject.Find ("Modifier").transform);
			f.GetComponent<Modify> ().gb = gameObject;
			f.name = "Force";

			d = Instantiate (deselect, GameObject.Find ("Modifier").transform);
			d.name = "Deselect";
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		}
	}

	private void Update ()
	{
		if (gb==null&& gameObject.tag == "Black Hole")
		{
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		}

		if (GameObject.Find ("Deselect") && GameObject.Find ("Deselect").GetComponent<Deselect> ().canActivate)
			activate (true);
	}

	private void spawnModifier ()
	{
		gb = Instantiate (modifier, GameObject.Find ("UI").transform);
		gb.transform.localPosition = new Vector3 (0, -330, 0);
		gb.name = "Modifier";
	}

	public void activate (bool boo)
	{
		scrollView.SetActive (boo);
		nextItem.SetActive (boo);
		preItem.SetActive (boo);
	}
}