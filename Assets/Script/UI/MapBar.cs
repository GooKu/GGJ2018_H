using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//地圖拉條

public class MapBar : MonoBehaviour {

    //拉條最大值的定植
    private const float barMax = 855;

    //開啟與關閉拖拉
    public bool flag = false;
	
	// Update is called once per frame
	void Update () {
        //傳輸現在的狀態至CameraController中
        if(CameraController.Instance != null && flag) {
            float p = Mathf.InverseLerp(0, Screen.width, Input.mousePosition.x);
            p = Mathf.Lerp(0, barMax, p);
            Vector3 pos = transform.localPosition;
            pos.x = p;
            transform.localPosition = pos;
            float x = Mathf.InverseLerp(0,barMax,transform.localPosition.x);
            CameraController.Instance.currentBar = x;
        }
	}

    //拖曳時執行
    public void OnDrag() {
        flag = true;
    }
    //拖曳時執行
    public void EndDrag() {
        flag = false;
    }
}
