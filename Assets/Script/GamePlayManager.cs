using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private MainUIManager mainUI;

    private StageConfig stageConfig;

    private void Start()
    {
        if (mainUI != null)
        {
            SetMainUI(mainUI);
        }
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

    public void SetMainUI(MainUIManager mainUI)
    {
        this.mainUI = mainUI;
        mainUI.TimeCounter.TimeOut += StartGame;
        mainUI.StartButton.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    public void Init()
    {
        var stageConfigGameobject = GameObject.Find("StageConfig");

        if (stageConfigGameobject == null) { return; }

        stageConfig = stageConfigGameobject.GetComponent<StageConfig>();

        if (stageConfig == null) { Debug.LogError("No Stage Config!!"); return; }

        mainUI.ItemBarUI.itemInfo = stageConfig.itemInfo;
        mainUI.ItemBarUI.AddItem();
        mainUI.TimeCounter.SetTime(stageConfig.StartTime);
    }

    public void StartGame()
    {
        mainUI.TimeCounter.TimeOut -= StartGame;
        mainUI.GameStartModel();

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
