﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterScript : MonoBehaviour {

    public GameObject TransmitterAntenna;

    public GameObject Signal;

    public float turnVelocity = 2.0f;

    public bool IsActive { get; set; }

    public void Turn(float delta)
    {
        TransmitterAntenna.transform.Rotate(Vector3.up, delta * turnVelocity);
    }

    public void FireMessage()
    {
        if (GameObject.FindGameObjectsWithTag("Signal").Length > 0)
        {
            return;
        }
        var stationPos = transform.Find("StationObject").gameObject.transform.position;
        var stationRot = transform.Find("StationObject/Antenna").gameObject.transform.rotation;
        // spawn MessageObject
        // Add velocity Antenna.Vector3.forward
        GameObject signalClone = Instantiate(Signal, stationPos, stationRot);
        Debug.Log("Spawning signal at" + transform.localPosition);


        //signalClone.GetComponent<MyRocketScript>().DoSomething();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
