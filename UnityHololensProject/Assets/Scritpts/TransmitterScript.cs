using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterScript : MonoBehaviour {

    public GameObject TransmitterAntenna;

    public GameObject Signal;

    public bool IsActive { get; set; }

    public void Turn(float delta)
    {
        TransmitterAntenna.transform.Rotate(Vector3.up, delta);
    }

    public void FireMessage()
    {

        // spawn MessageObject
        // Add velocity Antenna.Vector3.forward
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
