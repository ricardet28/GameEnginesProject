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
        Vector3 directionRay = new Vector3(controller.eyes.forward.x, 0f, controller.eyes.forward.z);
        if (controller.isFather)
        {
            if (Physics.SphereCast(startRayPosition, controller.enemyStats.lookSphereCastRadius, directionRay, out hit, controller.enemyStats.lookFatherRange)
            && (hit.collider.CompareTag("Player")) || hit.collider.CompareTag("EnemyBullet"))//entra en el if si está intersectando con algo, si ese algo es el player y si la distancia es menor que el rango de visión.
            {
                Debug.Log("aim to the player");
                controller.fatherDetectsPlayer = true;
                return true;
            }
            else
            {
                Debug.Log("por esto era");
                return false;
            }     
        }
        else
        {
            if (distance > controller.enemyStats.lookRange)
            {

                Quaternion desiredRotation = Quaternion.Euler(0f, controller.gameObject.transform.rotation.y, controller.gameObject.transform.rotation.z);
                controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, desiredRotation, 0f * Time.deltaTime);
                //controller.transform.rotation = Quaternion.Euler(0f, controller.transform.rotation.y, controller.transform.rotation.z);
                
                return false;

            }
            else
            {
                //controller.gameObject.transform.rotation = Quaternion.Euler(controller.gameObject.transform.rotation.x, controller.gameObject.transform.rotation.y, 0);
                return true;
            }

        }



    }
}
