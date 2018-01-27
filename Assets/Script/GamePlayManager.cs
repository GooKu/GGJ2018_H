using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    public MainUIManager MainUI;

    private StageConfig stageConfig;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level, LoadSceneMode.Single);
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode arg1)
    {
        Init();

        var debugger = GameObject.Find("StageDebugCanvas");

        if (debugger != null)
        {
            debugger.SetActive(false);
        }
    }

    public void Init()
    {
        var stageConfigGameobject = GameObject.Find("StageConfig");

        if (stageConfigGameobject == null) { return; }

        stageConfig = stageConfigGameobject.GetComponent<StageConfig>();

        if (stageConfig == null) { Debug.LogError("No Stage Config!!"); return; }

        MainUI.ItemBarUI.itemInfo = stageConfig.itemInfo;
        MainUI.ItemBarUI.AddItem();
        MainUI.TimeCounter.TimeOut += StartGame;
        MainUI.TimeCounter.SetTime(stageConfig.StartTime);
    }

    public void StartGame()
    {
        MainUI.TimeCounter.TimeOut -= StartGame;
        MainUI.GameStartModel();

        GameObject player = null;
        
        if(stageConfig.Light == null)
        {
            player = Resources.Load<GameObject>("Light");
        }
        else
        {
            player = stageConfig.Light;
        }

        if(stageConfig.StartPoint == null)
        {
            player = Instantiate(player);
        }
        else
        {
            player = Instantiate(player, stageConfig.StartPoint.position, new Quaternion());
        }

        var lightMovement = player.GetComponent<LightMovement>();
        lightMovement.UpdateSpeed(stageConfig.Speed);
        lightMovement.direction = stageConfig.StartPoint.right;
    }
}
