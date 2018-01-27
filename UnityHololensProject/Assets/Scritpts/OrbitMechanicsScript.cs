using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMechanicsScript : MonoBehaviour {

    public float orbitSpeed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, Time.deltaTime * orbitSpeed);
	}
}
