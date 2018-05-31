using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/DetectPlayer")]
public class DetectPlayerDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        
        RaycastHit hit;
        
        Vector3 startRayPosition = new Vector3(controller.eyes.position.x, 1f, controller.eyes.position.z);
        Vector3 directionRay = new Vector3(controller.eyes.forward.x, 0f, controller.eyes.forward.z);
        if (controller.isFather)
            Debug.DrawRay(startRayPosition, directionRay.normalized * controller.enemyStats.lookFatherRange, Color.cyan);
        else
        {
            Debug.DrawRay(startRayPosition, directionRay.normalized * controller.enemyStats.lookRange, Color.green);
        }

            
        if (controller.isFather)
        {
            if (Physics.SphereCast(startRayPosition, controller.enemyStats.lookSphereCastRadius, directionRay, out hit, controller.enemyStats.lookFatherRange)
            && hit.collider.CompareTag("Player"))
            {

                controller.chaseTarget = hit.transform;

                controller.fatherDetectsPlayer = true;
                controller.PlayPlayerDetectedAudio();
                return true;

            }
            else
            {
                controller.chaseTarget = null;
                controller.fatherDetectsPlayer = false;
                return false;
            }
        }

        else
        {
            if (Physics.SphereCast(startRayPosition, controller.enemyStats.lookSphereCastRadius, directionRay, out hit, controller.enemyStats.lookRange)
            && hit.collider.CompareTag("Player"))
            {

                controller.chaseTarget = hit.transform;

                return true;

            }
            else
            {
                controller.chaseTarget = null;
                return false;
            }
        }
        

        

    }

}
