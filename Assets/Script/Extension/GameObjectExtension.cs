using UnityEngine;

public static class GameObjectExtension
{
	public static bool IsPlayer(this GameObject gObj)
    {
        return gObj.CompareTag("Player");
    }
}
