using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //程式實體
    private static CameraController instance = null;

    //供外部抓取用，並且只能抓取
    public static CameraController Instance {
        get {
            // 還沒指定時就先尋找遊戲中有沒有一樣的
            if(instance == null) {
                instance = FindObjectOfType<CameraController>();

                // 還是沒有的話，就在MainCamera上建立一個新的
                if(instance == null) {
                    GameObject go = Camera.main.gameObject;
                    instance = go.AddComponent<CameraController>();
                }
            }

            return instance;
        }
    }

    //作用攝影機
    public Camera mainCamera;

    //攝影機狀態
    public enum CameraType {
        //跟隨拉條移動
        BarValue,
        //跟隨目標物
        FollowTarget,
        //靜止
        Stop,
    }

    //攝影機狀態
    public CameraType cameraType = CameraType.Stop;

    //攝影機跟隨的目標
    public Vector3 CameraTarget;

    //攝影機與目標的距離(目前暫定為-10)
    public float distanceZ = -10;

    //場景的邊界Collider
    public Bounds sceneArea;

    //拉條的最大值
    private const float BarMax = 855;

    //當前拉條進度
    public float currentBar = 0;

    //攝影機可移動範圍
    public Bounds moveBounds;

    //場上目前有的光體
    public List<Transform> lightList = new List<Transform>();

    //Debug
    public BoxCollider2D test;

    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;
        InitCamera(mainCamera,test);
	}

    //重置攝影機
    public void InitCamera(Camera c, BoxCollider2D moveArea) {
        //作用相機
        mainCamera = c;
        //設定邊界
        sceneArea = moveArea.bounds;
        //攝影機距離
        distanceZ = -10f;
        //計算攝影機可移動的範圍
        //計算相機高度
        float cameraHight = mainCamera.orthographicSize * 2;
        //螢幕長寬比
        float wRate = Screen.width / Screen.height;
        moveBounds = new Bounds(sceneArea.center,
            new Vector3(sceneArea.size.x - cameraHight * wRate,
            sceneArea.size.y - cameraHight,
            0));

    }

    //改變相機狀態
    public void ChangeType(CameraType t) {
        cameraType = t;
    }
	


	// Update is called once per frame
	void Update () {
        switch(cameraType) {
            case CameraType.BarValue:
                //計算x位置
                float x = Mathf.Lerp(moveBounds.min.x,moveBounds.max.x,currentBar);
                Vector3 pos = transform.position;
                pos.x = x;
                pos.y = moveBounds.center.y;
                CameraTarget = pos;
                SlideCamera();
                break;
            case CameraType.FollowTarget:
                //找到最右邊的物件
                if(lightList.Count !=0) {
                    float r = -100;
                    for(int i = 0; i < lightList.Count; i++) {
                        if(lightList[i].position.x > r) {
                            r = lightList[i].position.x;
                        }
                    }
                    pos = transform.position;
                    pos.x = r;
                    CameraTarget = pos;
                    MoveCamera(lightList);
                }
                break;
            case CameraType.Stop:
                break;
        }
    }

    public void AddLight(Transform obj) {
        lightList.Add(obj);
    }

    public void RemoveLight(Transform obj) {
        var light = lightList.Find(x => x == obj);
        if(light == null) { return; }
        lightList.Remove(light);
    }

    /// <summary>
    /// 移動專用攝影機
    /// </summary>
    /// <param name="objs">追隨物件表單</param>
    /// <returns>Camera的Size</returns>
    public void MoveCamera(List<Transform> objs ) {
        mainCamera.transform.position = CameraTarget;

        //攝影機縮放視野
        float max = 5;
        for(int i = 0; i < objs.Count; i++) {
            float dis = Mathf.Abs(objs[i].position.y);
            if(dis > max) {
                max = dis;
            }
        }
        mainCamera.orthographicSize = max;

        //重新計算攝影機可移動的範圍
        //計算相機高度
        float cameraHight = mainCamera.orthographicSize * 2;
        //螢幕長寬比
        float wRate = Screen.width / Screen.height;
        moveBounds = new Bounds(sceneArea.center,
            new Vector3(sceneArea.size.x - cameraHight*wRate,
            sceneArea.size.y - cameraHight,
            0));

        Vector3 pos = mainCamera.transform.position; 
        
        if(pos.x > moveBounds.max.x) {
            pos.x = moveBounds.max.x;
        } else if(pos.x < moveBounds.min.x) {
            pos.x = moveBounds.min.x;
        }
        
        if(pos.y >moveBounds.max.y) {
            pos.y = moveBounds.max.y;
        } else if(pos.y < moveBounds.min.y) {
            pos.y = moveBounds.min.y;
        }
        pos.y = 0;
        mainCamera.transform.position = pos;
    }

    /// <summary>
    /// 平移用攝影機
    /// </summary>
    /// <param name="objs">追隨物件表單</param>
    /// <returns>Camera的Size</returns>
    public void SlideCamera() {
        mainCamera.transform.position = CameraTarget;

        //重新計算攝影機可移動的範圍
        //計算相機高度
        float cameraHight = mainCamera.orthographicSize * 2;
        //螢幕長寬比
        float wRate = Screen.width / Screen.height;
        moveBounds = new Bounds(sceneArea.center,
            new Vector3(sceneArea.size.x - cameraHight * wRate,
            sceneArea.size.y - cameraHight,
            0));

        Vector3 pos = mainCamera.transform.position;

        if(pos.x > moveBounds.max.x) {
            pos.x = moveBounds.max.x;
        } else if(pos.x < moveBounds.min.x) {
            pos.x = moveBounds.min.x;
        }

        if(pos.y > moveBounds.max.y) {
            pos.y = moveBounds.max.y;
        } else if(pos.y < moveBounds.min.y) {
            pos.y = moveBounds.min.y;
        }

        mainCamera.transform.position = pos;
    }
}
