using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/PlayerInRangeChase")]
public class PlayerInRangeChaseDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool isThePlayerInRange = PlayerInRange(controller);
        return isThePlayerInRange;
    }

    public bool PlayerInRange(StateController controller)
    {
        float distance = Vector3.Distance(controller.eyes.position, controller.chaseTarget.position);
        RaycastHit hit;

        Vector3 startRayPosition = new Vector3(controller.eyes.position.x, 1f, controller.eyes.position.z);
        Vector3 directionRay = new Vector3(controller.eyes.forward.x, controller.eyes.forward.y, controller.eyes.forward.z);
        if (controller.isFather)
        {
            if (Physics.SphereCast(startRayPosition, controller.enemyStats.lookSphereCastRadius, directionRay, out hit, controller.enemyStats.lookFatherRange)
            && (hit.collider.gameObject.CompareTag("Player") || hit.collider.gameObject.CompareTag("EnemyBullet")))//entra en el if si está intersectando con algo, si ese algo es el player y si la distancia es menor que el rango de visión.
            {
                controller.fatherDetectsPlayer = true;
                controller.lastPositionPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
                return true;
            }
            else
            {
                return false;
            }     
        }
        else
        {
            if (distance > controller.enemyStats.lookRange)
            {
                controller.lastPositionPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;  
                return false;

            }
            else
            {
                controller.readyToScanAgain = false;
                return true;
            }

        }



    }
}
