using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RecolocateRotation")]
public class RecolocateRotationAction : ActionAI {
    public override void Act(StateController controller)
    {
        RecolocateRotation(controller);
    }
    private void RecolocateRotation(StateController controller)
    {

        Vector3 direction =  controller.lastPositionPlayer - controller.transform.position;
        direction.y = 0;
        
        Quaternion desiredRotation = Quaternion.LookRotation(direction);

        controller.lerpValue += Time.deltaTime * 1.5f;
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, desiredRotation, controller.lerpValue);


        if (controller.lerpValue >= 1)
        {
            controller.lerpValue = 0f;
            controller.readyToScanAgain = true;
            
        }
      
        
    }
   

}
