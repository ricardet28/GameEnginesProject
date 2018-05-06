using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Actions/Teleport")]
public class TeleportAction : ActionAI {

    public override void Act(StateController controller)
    {
        Teleport(controller);
    }
    private void Teleport(StateController controller)
    {
        if (controller.teleportAvalaible)
        {
            
            Transform nextPointToTeleport = controller.teleportPoints[Random.Range(0, controller.teleportPoints.Count)];
           
            Debug.Log("teleporting to another point!!");
            controller.transform.position = nextPointToTeleport.position;
            controller.transform.rotation = nextPointToTeleport.rotation;

            controller.currentPoint = nextPointToTeleport;
            controller.teleportAvalaible = false;

        }
    }
    
}
