using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    [HideInInspector]public Vector3 initialPosition;

    public GameObject father;
    public bool fatherDetectsPlayer;
    public bool isFather;
    public GameObject[] sons;

    public Rigidbody projectile;
    public Transform firePosition;

    public EnemyStats enemyStats;
    public Transform eyes;
    public State currentState;
    public State remainState;

    [HideInInspector]public NavMeshAgent navMeshAgent;
    public List<Transform> wayPointList;
    public int nextWayPoint;
    [HideInInspector]public Transform chaseTarget;
    [HideInInspector]public float stateTimeElapsed;


    Quaternion aimingPlayerRotation;
    bool canLerp;



    private Object[] states;

    private bool aiActive;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
        aiActive = true;

        if (sons.Length > 0)
        {
            isFather = true;
        }
        else
        {
            isFather = false;
        }
        StoreStates();
        
    }

    private void StoreStates()
    {
        states = Resources.LoadAll("Scripts/AI/ScriptableObjects/States/");
        Debug.Log("We have " + states.Length + " states");
    }

    public void SetupAI (bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
    {
        
        wayPointList = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }

    }

    private void Update()
    {
        //Debug.Log("aiActive = " + aiActive);
        if (!aiActive)
            return;
        currentState.UpdateState(this);

        //StateBehaviour();


    }


    public void StateBehaviour()
    {
        /*
        if (currentState == states[15])
        {
            //aiming player
            aimingPlayerRotation = this.transform.rotation;

        }
        */
        if (Mathf.Round(this.transform.position.x) == 0)
        {
            canLerp = false;
        }
        else
        {
            canLerp = true;
        }
        if (currentState == states[10] && canLerp)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0f, this.transform.rotation.y, this.transform.rotation.z), Time.deltaTime);
        }

    }


    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    public bool checkIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return stateTimeElapsed >= duration;
    }
    private void OnExitState()
    {
        stateTimeElapsed = 0f;
    }
}
