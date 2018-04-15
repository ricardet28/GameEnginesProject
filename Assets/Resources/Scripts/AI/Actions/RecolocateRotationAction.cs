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
        Quaternion desiredRotation = Quaternion.Euler(0f, controller.transform.rotation.y, controller.transform.rotation.z);
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, desiredRotation, 4f * Time.deltaTime);
    }

    
}
