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
    public List<Transform> teleportPoints;
    public Transform currentPoint;
    public int nextWayPoint;
    public Transform chaseTarget;
    [HideInInspector]public float stateTimeElapsed;


    Quaternion aimingPlayerRotation;
    bool canLerp;

    public bool readyToScanAgain;
    public Vector3 lastPositionPlayer;

    public float lerpValue;

    public float currentTimer;
    private float targetTimer;
    public bool teleportAvalaible;


    private Object[] states;

    private bool aiActive;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
        aiActive = true;
        

        
    }
    private void Start()
    {
        currentTimer = 0f;
        targetTimer = Random.Range(enemyStats.minTimeToTeleport, enemyStats.maxTimeToTeleport);
        if (teleportPoints.Count > 0)
        {
            currentPoint = teleportPoints[Random.Range(0, teleportPoints.Count)];
            transform.position = currentPoint.position;
            transform.rotation = currentPoint.rotation;
        }

        if (currentState.ToString() == "TeleportingShooting (State)")
        {
            chaseTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }



        if (sons.Length > 0)
        {
            isFather = true;
            SetSonsFather();
        }
        else
        {
            isFather = false;
        }
    }
    private void SetSonsFather()
    {
        foreach (GameObject son in sons)
        {
            son.GetComponentInChildren<StateController>().father = this.gameObject;
        }
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

        if (!aiActive)
            return;

        if (currentState.ToString() == "TeleportingShooting (State)")
        {
            //Debug.Log("handling time to teleport! ");
            handleTeleportTime();
        }
        currentState.UpdateState(this);

        //StateBehaviour();


    }

    private void handleTeleportTime()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer >= targetTimer)
        {
            Debug.Log("teleport");
            teleportAvalaible = true;
            currentTimer = 0f;
            targetTimer = Random.Range(enemyStats.minTimeToTeleport, enemyStats.maxTimeToTeleport);

        }
        
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
