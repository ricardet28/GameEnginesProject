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

        controller.lerpValue += Time.deltaTime * 5f;
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, desiredRotation, controller.lerpValue);

        Debug.Log("Actual: " + controller.transform.rotation);
        Debug.Log("Desired: " + desiredRotation);

        if (controller.lerpValue >= 1)
        {
            controller.lerpValue = 0f;
            controller.readyToScanAgain = true;
            
        }
      
        
    }
   

}
