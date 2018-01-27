using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GamePlayManager))]
public class StageDebugger : MonoBehaviour
{
    private GamePlayManager gm;
    public MainUIManager MainUI;

    private void Start()
    {
        var mainUI = Instantiate(MainUI);

        gm = GetComponent<GamePlayManager>();
        gm.itemBarUI = mainUI.ItemBarUI;
        gm.Init();
    }

    public void OnStargeGameClick()
    {
        gm.StartGame();
    }
}
