using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

    public Rigidbody2D rb;

    private Vector2 normal;
    private float IncidenceAngle;
    private float NormalAngle;
    private float angle;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 direction;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        normal = collision.contacts[0].normal;

        if (collision.gameObject.CompareTag("Mirror"))
        {
            normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(direction * speed);
	}
}
