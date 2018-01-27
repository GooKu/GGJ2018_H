using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageConfig : MonoBehaviour
{
    public GameObject Light;
    public float Speed = .1f;
    public Transform StartPoint;
    public ItemInfo[] itemInfo = new ItemInfo[0];
    public float StartTime = 5;
    public float GameTime = 30;
}
