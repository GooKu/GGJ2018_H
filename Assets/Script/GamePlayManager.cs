using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private int currentLevel = 1;

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
    }
}
