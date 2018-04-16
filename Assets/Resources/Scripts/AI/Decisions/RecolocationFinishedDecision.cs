using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RecolocationFinished")]

public class RecolocationFinishedDecision : Decision {


    public override bool Decide(StateController controller)
    {
        return IsFinished(controller);
    }

    private bool IsFinished(StateController controller)
    {
        
        if (controller.readyToScanAgain)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
