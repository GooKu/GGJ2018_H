using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lense : MonoBehaviour
{
    [SerializeField]
    private int splitNumber;

    private void Start()
    {
        if (splitNumber < 2)
        {
            splitNumber = 2;
        }
    }

    public int getNumber()
    {
        return splitNumber;
    }

}
