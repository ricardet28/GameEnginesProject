using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public GameObject topPosition;
    public GameObject basePosition;
    private Transform _topElevator;
    private Transform _baseElevator;
    enum elevatorStates { goUp, goDown};
    private elevatorStates states;
    public int speed;

	// Use this for initialization
	void Start () {
        _topElevator = topPosition.transform;
        _baseElevator = basePosition.transform;
        states = elevatorStates.goUp;
    }
	
	// Update is called once per frame
	void Update () {
        changeState();
        moveElevator();
    }

    void moveElevator()
    {
        if(states == elevatorStates.goUp)
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        if (states == elevatorStates.goDown)
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
    }
    
    void changeState()
    {
        if (transform.position.y >= _topElevator.position.y)
            states = elevatorStates.goDown;
        if (transform.position.y <= _baseElevator.position.y)
            states = elevatorStates.goUp;
    }
}
