using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class LightMovement : MonoBehaviour {

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
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lense"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            int splitNumber = collision.gameObject.GetComponent<Lense>().getNumber();
            float angle = 0f;
            List<GameObject> newLights = new List<GameObject>();
            angle = 180 / (splitNumber + 1);
            Debug.Log(direction);
            for (int i = 0; i < splitNumber; i++)
            {
                newLights.Add(Instantiate(this.gameObject));
                float newAngle = angle * (i + 1);
                float rad = newAngle * Mathf.Deg2Rad;
                if (collision.transform.rotation.z == 0 || collision.transform.rotation.z == 180)
                    newLights[i].GetComponent<LightMovement>().direction =
                        (new Vector2(Mathf.Sin(rad), Mathf.Cos(rad))).normalized;
                else
                    newLights[i].GetComponent<LightMovement>().direction =
                        (new Vector2(Mathf.Cos(rad), Mathf.Sin(rad))).normalized;
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(direction * speed);
	}

    public void Stop()
    {
        direction = Vector2.zero;
		StartCoroutine (checkDeath ());
    }

    private IEnumerator checkDeath()
    {
        float limitTime = 0;
        do {
            yield return null;
            limitTime += Time.deltaTime;
        } while (trail.isVisible && limitTime < 10);
        Destroy(gameObject);
    }

    public void UpdateDirection(Vector2 direc)
    {
        direction = direc;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
