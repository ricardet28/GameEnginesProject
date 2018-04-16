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
        Vector3 direction = controller.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
        direction.y = 0;
        Quaternion desiredRotation = Quaternion.LookRotation(direction);
        //Quaternion desiredRotation = Quaternion.LookRotation(controller.gameObject.transform.forward);
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, desiredRotation, 1f * Time.deltaTime);
    }

    
}
