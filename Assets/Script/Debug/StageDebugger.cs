using System.Collections;
using UnityEngine;

public class StageDebugger : MonoBehaviour
{
    public MainUIManager MainUI;
    public MainDebugger MainDebugger;
    public GamePlayManager GM;

    private void Start()
    {
        if (GameObject.FindObjectOfType(typeof(GamePlayManager)))
        {
            gameObject.SetActive(false);
        }
    }

    public void OnStargeGameClick()
    {
        var mainUI = Instantiate(MainUI);
        var mainDebugger = Instantiate(MainDebugger);
        GM = Instantiate(GM);
        GM.SetMainUI(mainUI);
        GM.Init();
        mainDebugger.SetGamePlayManager(GM);
        gameObject.SetActive(false);
    }
}
