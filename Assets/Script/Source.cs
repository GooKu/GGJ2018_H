using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    [SerializeField]
    private GameObject light;
    public void Start()
    {
        var newLight = GameObject.Instantiate(light, transform.position, new Quaternion());

        var movement = newLight.GetComponent<LightMovement>();
        if (movement == null) { Debug.LogWarning("Player has no movement"); return; }

        movement.UpdateDirection(transform.right);
    }
}
