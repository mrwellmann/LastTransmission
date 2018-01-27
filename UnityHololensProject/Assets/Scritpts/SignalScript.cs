using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalScript : MonoBehaviour {

    private Rigidbody MyRigidbody;

    public float transmissionSpeed = 3.0f;

    private void Awake()
    {
        MyRigidbody = GetComponentInChildren<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        MyRigidbody.velocity = transform.forward * transmissionSpeed;
    }

    private void FixedUpdate()
    {
        // if collided with Planet -> Game Over
        // if collided with Station -> New Station is active 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
