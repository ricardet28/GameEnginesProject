using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour {
    private LineRenderer _line;
    private StateController _controller;

    public float fatherRayLength;
    // Use this for initialization

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _controller = GetComponentInParent<StateController>();
    }
    void Start () {
        //_line.SetPosition(0, this.transform.position);

        
	}
	
	// Update is called once per frame
	void Update () {
        //_line.SetPosition(0, this.transform.position);
        //_line.SetPosition(1, this.transform.forward.normalized * fatherRayLength);

        if (_controller.fatherDetectsPlayer)
        {
            //_line.SetPosition(1, _controller.chaseTarget.transform.position);
        }
    }
}
