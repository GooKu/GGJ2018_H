using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public Text ResultText;
    public Button RestartButton;
    public Button ReturnButton;

	public void ShowPass(int point)
    {
        ResultText.text = "Complete";
        show(point);
    }

    public void ShowFail(int point)
    {
        ResultText.text = "Fail";
        show(point);
    }

    private void show(int point)
    {
        //TODO:show point
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
