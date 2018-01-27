using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public ItemBarUI ItemBarUI;
    public TimeCounter TimeCounter;
    public StartBtn StartButton;
    public Text CountDownText;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        CountDownText.enabled = false;
    }

    public void GameStartModel()
    {
        TimeCounter.StopAllCoroutines();
        anim.Play("GameStart");
        CountDownText.enabled = true;
    }
}
