using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterStationControll : MonoBehaviour {

    public GameObject[] transmitterStations;

    private TransmitterScript activeStation;

    private void Awake()
    {
        activeStation = transmitterStations[0].GetComponent<TransmitterScript>(); ;
    }

    public void ActivateStation(int stationNo)
    {
        foreach(GameObject transmitter in transmitterStations)
        {
            transmitter.GetComponent<TransmitterScript>().IsActive = false;
        }
        transmitterStations[stationNo].GetComponent<TransmitterScript>().IsActive = true;
        activeStation = transmitterStations[stationNo].GetComponent<TransmitterScript>();
    }
	
	// Update is called once per frame
	void Update () {
        //bool right = Input.GetButton("right");
        //bool left = Input.GetButton("left");
        bool fire = Input.GetButton("FireMessage");
        float horizontal = Input.GetAxis("Horizontal");
        //activeStation.Turn(horizontal);
        if (horizontal != 0.0f)
        {

            activeStation.Turn(horizontal);
        }
        //else if (left)
        //{
        //    activeStation.Turn(-1.0f);
        //}
        if (fire)
        {
            Debug.Log("Fire received.");
            activeStation.FireMessage();
        }

    }
}
