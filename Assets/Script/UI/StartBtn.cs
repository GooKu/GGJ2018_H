using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//開始用按鈕

public class StartBtn : MonoBehaviour {

    //代表開始中的貼圖
    public Sprite startTex;
    //代表等待中的的貼圖
    public Sprite waitTex;
    //True表示遊戲進行中
    public bool isPlaying = false;

	public GameObject [] gb;

    //按下按鈕時發生
    public void OnBtnPress()
    {
        SetEnable(false);
		if (SceneManager.GetActiveScene ().name == "Level2")
		{
			gb = GameObject.FindGameObjectsWithTag ("Black Hole");
			foreach (GameObject g in gb)
			{
				Debug.Log (g.name);
				g.GetComponent<CircleCollider2D> ().radius = 3.5f;
			}
		}
    }

    public void SetEnable(bool enable)
    {
        if (enable)
        {
            GetComponent<Image>().sprite = waitTex;
        }
        else
        {
            GetComponent<Image>().sprite = startTex;
        }
        GetComponent<Button>().interactable = enable;
    }
}
