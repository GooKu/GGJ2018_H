using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    public ItemBarUI ItemBarUI;
    public TimeCounter TimeCounter;
    public StartBtn StartButton;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void GameStartModel()
    {
        TimeCounter.StopAllCoroutines();
        anim.Play("GameStart");
    }
}
