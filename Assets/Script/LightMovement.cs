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
		StartCoroutine (checkDeath ());
	}

	private IEnumerator checkDeath ()
	{
		float limitTime = 0;
		do
		{
			yield return null;
			limitTime += Time.deltaTime;
		} while (trail.isVisible && limitTime < 10);
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