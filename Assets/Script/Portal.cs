using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private Portal linkedPortal;

    private bool isTransmitting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTransmitting) { return; }

        if (!collision.gameObject.IsPlayer()) { return; }

        var movement = collision.GetComponent<LightMovement>();

        if(movement == null) { Debug.LogWarning("Player has no movement"); return; }

        if (linkedPortal == null) { return; }

        linkedPortal.Transmit(collision.gameObject);
        movement.Stop();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.IsPlayer()) { return; }
        isTransmitting = false;
    }

    public void Transmit(GameObject source)
    {
        var newLight = GameObject.Instantiate(source, transform.position, new Quaternion());

        isTransmitting = true;

        var movement = newLight.GetComponent<LightMovement>();
        if (movement == null) { Debug.LogWarning("Player has no movement"); return; }

        movement.UpdateDirection(transform.right);
    }
}
