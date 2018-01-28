using UnityEngine;

public class PlayerInfo
{
    public static int GetPoint(int level)
    {
        return PlayerPrefs.GetInt("level" + level, 0);
    }

    public static void SetPoint(int level, int point)
    {
        PlayerPrefs.SetInt("level" + level, point);
    }

}
