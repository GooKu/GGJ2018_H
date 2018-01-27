using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private MainUIManager mainUI;

    private StageConfig stageConfig;

    private float playTime = 0;

    private int getPoint = 0;

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
    }

    public void HideDebugger()
    {
        var debugger = GameObject.Find("StageDebugCanvas");

        if (debugger != null)
        {
            debugger.SetActive(false);
        }
    }

    public void SetMainUI(MainUIManager mainUI)
    {
        this.mainUI = mainUI;
        mainUI.transform.SetParent(this.transform);
        mainUI.TimeCounter.TimeOut += StartGame;
        mainUI.StartButton.GetComponent<Button>().onClick.AddListener(StartGame);
        mainUI.Result.RestartButton.onClick.AddListener(onRestart);
        mainUI.Result.ReturnButton.onClick.AddListener(OnReturnToMenu);
    }

    public void Init()
    {
        var stageConfigGameobject = GameObject.Find("StageConfig");

        if (stageConfigGameobject == null) { return; }

        stageConfig = stageConfigGameobject.GetComponent<StageConfig>();

        if (stageConfig == null) { Debug.LogError("No Stage Config!!"); return; }

        if(mainUI == null) { Debug.LogError("No Main UI!!"); return; }

        mainUI.GamePrepareMode();

        mainUI.ItemBarUI.itemInfo = stageConfig.itemInfo;
        mainUI.ItemBarUI.AddItem();
        mainUI.TimeCounter.SetTime(stageConfig.StartTime);

        stageConfig.End.OnArrived += OnGamePass;
    }

    public void StartGame()
    {
        mainUI.GameStartModel();

        getPoint = 0;

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

        playTime = stageConfig.GameTime;

        StartCoroutine(onGameTick());
    }

    private IEnumerator onGameTick()
    {
        do
        {
            playTime -= Time.deltaTime;
            if(playTime <= 0)
            {
                mainUI.CountDownText.text = "0";
                OnGameFail();
                //TODO: end Game
                yield break;
            }

            mainUI.CountDownText.text = playTime.ToString("0");
            yield return null;
        } while (true);
    }

    public void OnGamePass()
    {
        gameEndHandle();
        mainUI.Result.ShowPass(getPoint);
    }

    public void OnGameFail()
    {
        gameEndHandle();
        mainUI.Result.ShowFail(getPoint);
    }

    private void gameEndHandle()
    {
        StopAllCoroutines();
        stageConfig.End.OnArrived -= OnGamePass;
    }

    private void onRestart()
    {

    }

    private void OnReturnToMenu()
    {

    }
}
