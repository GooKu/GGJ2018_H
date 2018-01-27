using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    [SerializeField]
    private GameObject light;
	void Start()
    {
        light = Instantiate(light, transform.position, transform.rotation);
        Debug.Log(transform.right);
        light.GetComponent<LightMovement>().direction = transform.right.normalized;
    }
}
