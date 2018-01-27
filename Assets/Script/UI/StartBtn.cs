using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//開始用按鈕

public class StartBtn : MonoBehaviour {

    //代表開始中的貼圖
    public Sprite startTex;
    //代表等待中的的貼圖
    public Sprite waitTex;
    //True表示遊戲進行中
    public bool isPlaying = false;

    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
    }

    //按下按鈕時發生
    public void OnBtnPress() {
        //切換按鈕狀態
        if(isPlaying) {
            GetComponent<Image>().sprite = waitTex;
            isPlaying = !isPlaying;


        } else {
            GetComponent<Image>().sprite = startTex;
            isPlaying = !isPlaying;
        }
    }

    public void SwitchButtonMode()
    {
        if (btn.interactable)
        {
            GetComponent<Image>().sprite = waitTex;
        }
        else
        {
            GetComponent<Image>().sprite = startTex;
        }
        btn.interactable = !btn.interactable;
    }
}
