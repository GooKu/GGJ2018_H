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

    private void Start()
    {
        if(gM != null)
        {
            transform.SetParent(gM.transform);
        }
    }

    public void SetGamePlayManager(GamePlayManager gM)
    {
        this.gM = gM;
        transform.SetParent(gM.transform);
    }

    public void OnLoadLevelClick()
    {
        gM.LoadLevel(int.Parse(TestLevelInput.text));
    }

    public void StartGame()
    {
        gM.StartGame();
    }

    public void OnGamePassClick()
    {
        gM.OnGamePass();
    }

    public void OnGameFailClick()
    {
        gM.OnGameFail();
    }
}
