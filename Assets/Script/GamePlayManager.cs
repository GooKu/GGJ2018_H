using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private int currentLevel = 1;

    private StageConfig stageConfig;

    private UnityEngine.SceneManagement.Scene currentScene;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel(int level)
    {
        if(currentScene.IsValid())
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        SceneManager.LoadScene("Level" + level, LoadSceneMode.Additive);
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode arg1)
    {
        currentScene = scene;
         var stageConfigGameobject = GameObject.Find("StageConfig");

        if(stageConfigGameobject == null) { return; }

        stageConfig = stageConfigGameobject.GetComponent<StageConfig>();
    }

    public void StartGame()
    {
        if(stageConfig == null) { Debug.LogError("No Stage Config!!"); }

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
            player = Instantiate(player, stageConfig.StartPoint.position, stageConfig.StartPoint.rotation);
        }

        var lightMovement = player.GetComponent<LightMovement>();
        lightMovement.UpdateSpeed(stageConfig.Speed);
    }
}
