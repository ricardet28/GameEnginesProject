using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    public static AIManager instance = null;
    StateController[] _stateControllers;

    private void Awake()
    {
        instance = this;
        initializeStateControllersArray();   
    }
    private void initializeStateControllersArray()
    {
        _stateControllers = new StateController[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _stateControllers[i] = transform.GetChild(i).gameObject.GetComponentInChildren<StateController>();
        }
        Debug.Log("Tenemos " + _stateControllers.Length + " statesControllers!!");
    }

    public void DisableAI()
    {    
        foreach (StateController st in _stateControllers)
        {
            st.aiActive = false;
        }
    }

    public void EnableAI()
    {
        foreach (StateController st in _stateControllers)
        {
            st.aiActive = true;
        }
    }
}
