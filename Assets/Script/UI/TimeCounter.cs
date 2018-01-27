using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//時間倒數用

public class TimeCounter : MonoBehaviour {

    //捷徑
    public static TimeCounter order;

    //當True時執行倒數
    //public bool counting = false;

    //時間
    public static float time = 60;

    //顯示時間用
    public Text showTime;

    public Action TimeOut = delegate () { };

	// Use this for initialization
	void Start () {
        order = this;
	}
	

    public void SetTime(float t) {
        time = t;
        StopAllCoroutines();
        StartCoroutine("Count");
    }

    IEnumerator Count() {
        while(time > 0) {
            time -= Time.deltaTime;
            if(time <0)  time =0;
            showTime.text = time.ToString("F0");
            yield return 0;
        }

        //時間倒數結束要做的事情
        TimeOut();

        yield return 0;
    }

}
