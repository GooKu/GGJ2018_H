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
        if (!collision.gameObject.IsPlayer()) { return; }

        var controller = collision.GetComponent<LightMovement>();

        if(controller == null) { Debug.LogWarning("Player"); return; }

        //TODO
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.IsPlayer()) { return; }
    }

    public void Transmit()
    {

    }
}
