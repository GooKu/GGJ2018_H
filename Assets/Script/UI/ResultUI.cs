using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public Image Star;
    public Image ResultImage;
    public Sprite PassSprite;
    public Sprite FailSprite;
    public Button RestartButton;
    public Button ReturnButton;

	public void ShowPass(int point)
    {
        ResultImage.sprite = PassSprite;
        show(point);
    }

    public void ShowFail(int point)
    {
        ResultImage.sprite = FailSprite;
        show(point);
    }

    private void show(int point)
    {
        ResultImage.SetNativeSize();
        Star.sprite = Resources.Load<Sprite>("Score_Star_"+point);
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
