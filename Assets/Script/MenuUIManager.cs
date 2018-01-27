using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public int TotalLevel = 3;
    public Button SampleButton;
    public Transform ButtonGroup;

    private int currentSelectLevel;

    private void Start()
    {
        for(int i = 0; i < TotalLevel; i++)
        {
            var btn = GameObject.Instantiate(SampleButton, ButtonGroup);
            btn.gameObject.SetActive(true);
            int level = i + 1;
            btn.onClick.AddListener(()=> { onSelectSceneClick(level); });
        }
        DontDestroyOnLoad(this);
    }

    private void onSelectSceneClick(int level)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        currentSelectLevel = level;
        SceneManager.LoadScene("Main");
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode arg1)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        var gm = GameObject.FindObjectOfType<GamePlayManager>();
        if(gm == null) { return; }
        gm.LoadLevel(currentSelectLevel);
        Destroy(gameObject);
    }
}
