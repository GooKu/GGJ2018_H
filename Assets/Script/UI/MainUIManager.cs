using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    public ItemBarUI ItemBarUI;
    public TimeCounter TimeCounter;
    public GameObject StartButton;

    public void GameStartModel()
    {
        StartButton.SetActive(false);
    }
}
