using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start () {
        order = this;
        SetTime(60);
	}
	

    public void SetTime(float t) {
        time = t;
        StartCoroutine("Count");
    }

    IEnumerator Count() {
        while(time > 0) {
            time -= Time.deltaTime;
            if(time <0)  time =0;
            showTime.text = time.ToString();
            yield return 0;
        }

        //時間倒數結束要做的事情


        yield return 0;
    }

}
