using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/ScanIdle")]
public class ScanIdleAction : ActionAI {

    public override void Act(StateController controller)
    {
        TurnAndScan(controller);
    }

    private void TurnAndScan(StateController controller)
    {

        controller.gameObject.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
        //Debug.Log(controller.transform.rotation);
        //controller.transform.rotation = Quaternion.Euler(0f, controller.transform.rotation.y + controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
        //controller.gameObject.transform.rotation = Quaternion.Slerp(controller.gameObject.transform.rotation, Quaternion.Euler(0f, controller.gameObject.transform.rotation.y, controller.gameObject.transform.rotation.z), 10 * Time.deltaTime);
        //controller.gameObject.transform.rotation = Quaternion.Lerp(controller.gameObject.transform.rotation, Quaternion.LookRotation(controller.gameObject.GetComponentInParent<Transform>().forward), controller.enemyStats.searchingTurnSpeed * Time.deltaTime);
        controller.gameObject.transform.rotation = Quaternion.Lerp(controller.gameObject.transform.rotation, controller.gameObject.GetComponentInParent<Transform>().rotation,controller.enemyStats.searchingTurnSpeed * Time.deltaTime);
    }
}
