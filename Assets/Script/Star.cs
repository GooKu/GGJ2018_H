using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Star : MonoBehaviour
{
    public Action OnGetStartEvent = delegate () { };

    public GameObject Effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.IsPlayer()) { return; }

        OnGetStartEvent();

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Effect.SetActive(true);
        StartCoroutine(death());
    }

    private IEnumerator death()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

}
