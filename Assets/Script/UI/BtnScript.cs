using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//道具按鈕程式碼

public class BtnScript : MonoBehaviour {

    //被拖曳時複製的物件
    public GameObject copyItem;

    //有東西表示拖曳中
    private Transform dragItem = null;

    //使用次數，歸零時銷毀
    public int useTime = 0;


    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //拖曳物件若有指定則滑鼠放開前都會跟著移動
        if(dragItem != null) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            dragItem.position = pos;
        }
    }

    //拖曳時執行程式碼
    public void OnStartDrag() {
        //複製物件
        dragItem = Instantiate(copyItem,Vector3.zero,Quaternion.identity).transform;
		dragItem.gameObject.AddComponent<Drag> ();
		//使用次數-1
        
    }

    //放開時執行程式碼
    public void OnEndDrag() {
        //丟下物件
        dragItem = null;
    }
    

}
