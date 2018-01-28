using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
	public void OnStartClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

    }
}
