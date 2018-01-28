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
    public ResultUI Result;

    private Animator anim { get { return GetComponent<Animator>(); } }

    public void GamePrepareMode()
    {
        CountDownText.enabled = false;
        Result.gameObject.SetActive(false);
        StartButton.SetEnable(true);
        anim.Play("GamePrepare");
    }

    public void GameStartModel()
    {
        TimeCounter.StopAllCoroutines();
        anim.Play("GameStart");
        CountDownText.enabled = true;
    }
}
