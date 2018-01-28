using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (TrailRenderer))]
[RequireComponent (typeof (Rigidbody2D))]
public class LightMovement : MonoBehaviour
{

	public Rigidbody2D rb;

	private Vector2 normal;
	private float IncidenceAngle;
	private float NormalAngle;
	private float angle;
	private TrailRenderer trail;
	[SerializeField]
	private float speed;
	[SerializeField]
	public Vector2 direction;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		trail = GetComponent<TrailRenderer> ();
    }

	private void OnCollisionEnter2D (Collision2D collision)
	{
		normal = collision.contacts [0].normal;

		if (collision.gameObject.CompareTag ("Mirror"))
		{
			normal = collision.contacts [0].normal;
			direction = Vector2.Reflect (direction, normal);
			transform.Find ("Child").transform.Rotate (new Vector3 (0, 0, 90 - Vector2.Angle (direction, normal)));
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.Translate (direction * speed);
	}

	public void Stop ()
	{
		direction = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static ;
		StartCoroutine (checkDeath ());
	}

	private IEnumerator checkDeath ()
	{
		do
		{
			yield return null;
//            Debug.Log(trail.positionCount);
		} while (trail.positionCount > 0);

        if(gameObject == null) { yield break; }
		Destroy (gameObject);
	}

	public void UpdateSpeed (float s)
	{
		speed = s;
	}

	public void UpdateDirection (Vector2 direc)
	{
		direction = direc;
	}

	public float GetSpeed ()
	{
		return speed;
	}

	public Vector2 GetDirection ()
	{
		return direction;
	}
}