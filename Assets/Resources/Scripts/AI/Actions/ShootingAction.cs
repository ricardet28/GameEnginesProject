using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Actions/Shooting")]
public class ShootingAction : ActionAI {

    public override void Act(StateController controller)
    {
        ShootPlayer(controller);
    }
    
    private void ShootPlayer(StateController controller)
    {
        Vector3 direction = (controller.chaseTarget.position - controller.transform.position);
        controller.transform.rotation = Quaternion.LookRotation(direction);
        RaycastHit hit;

        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, direction, out hit, 300)
            && hit.collider.CompareTag("Player"))
        {
            if (controller.checkIfCountDownElapsed(controller.enemyStats.attackRate2))
            {
                Debug.Log("SHOOTING!!");
                Rigidbody projectileInstance = (Rigidbody)Instantiate(controller.projectile, controller.eyes.position, controller.eyes.rotation);
                //projectileInstance.velocity = Vector3.Distance(controller.transform.position, controller.chaseTarget.position) * controller.enemyStats.attackForce * controller.firePosition.forward;
                projectileInstance.velocity = Vector3.Distance(controller.transform.position, controller.chaseTarget.position) * controller.enemyStats.attackForce * direction.normalized;
                controller.stateTimeElapsed = 0f;

            }
        }

    }
}
