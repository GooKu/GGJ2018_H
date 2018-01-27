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
    //父物件
    public Transform itemRoot;

    //道具表單
    [Tooltip("道具表單")]
    public ItemInfo[] itemInfo = new ItemInfo[4];

    

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {


    }

    //新增按鈕
    public void AddItem() {
        Debug.Log(itemInfo.Length);
        //複製按鈕
        for(int i = 0; i < itemInfo.Length; i++) {
            GameObject item = Instantiate(itemInfo[i].icon,Vector3.zero,Quaternion.identity,itemRoot) as GameObject;
            item.transform.parent = itemRoot;
        }
    }

}
