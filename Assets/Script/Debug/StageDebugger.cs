using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDebugger : MonoBehaviour
{
	public void OnStargeGameClick()
    {
        StageConfig stageConfig = GameObject.Find("StageConfig").GetComponent<StageConfig>();
        if (stageConfig == null) { Debug.LogError("No Stage Config!!"); }

        GameObject player = null;

        if (stageConfig.Light == null)
        {
            player = Resources.Load<GameObject>("Light");
        }
        else
        {
            player = stageConfig.Light;
        }

        if (stageConfig.StartPoint == null)
        {
            player = Instantiate(player);
        }
        else
        {
            player = Instantiate(player, stageConfig.StartPoint.position, stageConfig.StartPoint.rotation);
        }

        var lightMovement = player.GetComponent<LightMovement>();
        lightMovement.UpdateSpeed(stageConfig.Speed);
        lightMovement.direction = stageConfig.StartPoint.right;
    }
}
