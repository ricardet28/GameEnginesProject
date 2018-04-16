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
        Debug.Log("hola");
        //Quaternion desiredRotation = Quaternion.LookRotation(controller.gameObject.GetComponentInParent<Transform>().right);
        //Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
        Vector3 direction =  controller.lastPositionPlayer - controller.transform.position;
        //direction.y = controller.transform.position.y;
        direction.y = 0;
        
        Quaternion desiredRotation = Quaternion.LookRotation(direction);

        controller.lerpValue += 0.01f;
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, desiredRotation, controller.lerpValue);

        Debug.Log("Actual: " + controller.transform.rotation);
        Debug.Log("Desired: " + desiredRotation);

        /*
        if (controller.transform.rotation == desiredRotation)
        {
            controller.readyToScanAgain = true;
        }
        */
        if (controller.lerpValue >= 1)
        {
            controller.readyToScanAgain = true;
        }
        
        /*
        if (Mathf.RoundToInt(controller.transform.rotation.x) == Mathf.RoundToInt(desiredRotation.x) &&
            Mathf.RoundToInt(controller.transform.rotation.y) == Mathf.RoundToInt(desiredRotation.y) &&
            Mathf.RoundToInt(controller.transform.rotation.z) == Mathf.RoundToInt(desiredRotation.z))
        {
            controller.readyToScanAgain = true;
        }
        */
        
        
    }
   

}
