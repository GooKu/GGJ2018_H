using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//道具class
[System.Serializable]
public class ItemInfo {
    [Tooltip("放上Item的UI")]
    public GameObject icon;
    public int number;
}

//道具欄位的UI
public class ItemBarUI : MonoBehaviour {

    //捷徑
    public static ItemBarUI order;

    //父物件
    public Transform itemRoot;

    //道具表單
    [Tooltip("道具表單")]
    public ItemInfo[] itemInfo = new ItemInfo[4];

    //當前的按鈕表單(用來清空表單用)
    public Queue<GameObject> currentBtnList = new Queue<GameObject>();

    // Use this for initialization
    void Start() {       
        AddItem();
        order = this;
    }

    // Update is called once per frame
    void Update() {


    }

    //新增按鈕
    public void AddItem() {
        //如果先前的表單有東西則清空
        while(currentBtnList.Count != 0) {
            Destroy(currentBtnList.Dequeue());
        }
        //複製按鈕
        for(int i = 0; i < itemInfo.Length; i++) {
            GameObject item = Instantiate(itemInfo[i].icon,Vector3.zero,Quaternion.identity,itemRoot) as GameObject;
            item.transform.SetParent(itemRoot);
            currentBtnList.Enqueue(item);
        }
    }

}
