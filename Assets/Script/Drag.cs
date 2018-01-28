using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
	private void OnMouseDrag ()
	{
		Vector3 pos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		Vector3 objpos = Camera.main.ScreenToWorldPoint (pos);
		transform.position = objpos;
	}
}