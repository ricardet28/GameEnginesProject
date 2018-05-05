using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Aim")]
public class AimAction : ActionAI {

    public override void Act(StateController controller)
    {
        Aim(controller);
    }

    private void Aim (StateController controller) { 


        Vector3 direction = controller.chaseTarget.position - controller.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Vector3 startRayPosition = new Vector3(controller.eyes.position.x, 1f, controller.eyes.position.z);
        Vector3 directionRay = new Vector3(controller.eyes.forward.x, 0f, controller.eyes.forward.z);

        if (controller.isFather)
        {
            controller.transform.rotation = targetRotation;
            Debug.DrawRay(startRayPosition, directionRay.normalized * controller.enemyStats.attackRange, Color.black);
        }
        else
        {
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, targetRotation, 4f * Time.deltaTime);
            Debug.DrawRay(startRayPosition, directionRay.normalized * controller.enemyStats.attackRange, Color.red);
        }
        
    }
}
