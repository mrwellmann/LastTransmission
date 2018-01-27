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

    private void FixedUpdate()
    {
        foreach (GameObject transmitter in transmitterStations)
        {
            if (transmitter.GetComponent<TransmitterScript>().IsActive)
            {
                activeStation = transmitter.GetComponent<TransmitterScript>();
            }
        }
        
    }

    // Update is called once per frame
    void Update () {
        bool fire = Input.GetButton("FireMessage");
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0.0f)
        {
            activeStation.Turn(horizontal);
        }

        if (fire)
        {
            activeStation.FireMessage();
        }

    }
}
