using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//黑洞程式碼

public class BlackHole : MonoBehaviour {

    //黑洞力道
    public float force = 0.001f;

    //黑洞半徑(最大可影響範圍)
    private float effDis;

    //旗幟
    private bool flag;

    // Use this for initialization
    void Start() {
        effDis = GetComponent<CircleCollider2D>().radius;
    }

    //進入黑洞時發生
    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            flag = true;
            StartCoroutine(BlackHoleWork(collision.transform));
        }
    }

    //離開黑洞時發生
    public void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player") {
            flag = false;
        }
    }

    IEnumerator BlackHoleWork(Transform target) {
        float dis = Vector2.Distance(transform.position, target.position);
        
        while(flag) {
			//計算單位向量
			if (target != null)
			{
				Vector2 dir = transform.position - target.position;
				dir = dir.normalized;

				//獲得物件與黑洞的距離
				dis = Vector2.Distance (transform.position, target.position);

				//計算黑洞引力
				float f = Mathf.InverseLerp (effDis, 0, dis);
				print (effDis + "  " + dis);
				f = Mathf.Lerp (0, force / 1000, f);

				//影響物件
				target.GetComponent<Rigidbody2D> ().AddForce (dir * f);

				//時間間隔
				yield return new WaitForSeconds (0.1f);
			}
        }
        
    }
}
