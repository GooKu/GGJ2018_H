using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Star : MonoBehaviour
{
    public Action OnGetStartEvent = delegate () { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.IsPlayer()) { return; }

        OnGetStartEvent();

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        //TODO:play partical
    }

}
