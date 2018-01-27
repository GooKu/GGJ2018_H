using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDebugger : MonoBehaviour
{
    [SerializeField]
    private GamePlayManager gM;
    [SerializeField]
    private InputField TestLevelInput;

    public void OnLoadLevelClick()
    {
        Debug.Log(TestLevelInput.text);
        gM.LoadLevel(int.Parse(TestLevelInput.text));
    }

    public void StartGame()
    {
        gM.StartGame();
    }
}
