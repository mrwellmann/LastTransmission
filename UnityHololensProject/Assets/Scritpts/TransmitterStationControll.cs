using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterStationControll : MonoBehaviour {

    public GameObject[] transmitterStations;

    public void ActivateStation(int stationNo)
    {
        foreach(GameObject transmitter in transmitterStations)
        {
            transmitter.GetComponent<TransmitterScript>().IsActive = false;
        }
        transmitterStations[stationNo].GetComponent<TransmitterScript>().IsActive = true;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
