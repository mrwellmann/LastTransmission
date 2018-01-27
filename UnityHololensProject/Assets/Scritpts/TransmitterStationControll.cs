using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterStationControll : MonoBehaviour {

    public GameObject[] TransmitterStations;
    public bool Hololens = false;
    public TransmitterScript ActiveStation;

    private void Awake()
    {
        ActiveStation = TransmitterStations[0].GetComponent<TransmitterScript>(); ;
    }

    public void ActivateStation(int stationNo)
    {
        foreach(GameObject transmitter in TransmitterStations)
        {
            transmitter.GetComponent<TransmitterScript>().IsActive = false;
        }
        TransmitterStations[stationNo].GetComponent<TransmitterScript>().IsActive = true;
        ActiveStation = TransmitterStations[stationNo].GetComponent<TransmitterScript>();
    }

    private void FixedUpdate()
    {
        foreach (GameObject transmitter in TransmitterStations)
        {
            if (transmitter.GetComponent<TransmitterScript>().IsActive)
            {
                ActiveStation = transmitter.GetComponent<TransmitterScript>();
            }
        }
        
    }

    // Update is called once per frame
    void Update () {

        if (!Hololens)
        {
            bool fire = Input.GetButton("FireMessage");
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal != 0.0f)
            {
                ActiveStation.Turn(horizontal);
            }

            if (fire)
            {
                ActiveStation.FireMessage();
            }
        }
    }

    public void FireSignal()
    {
        ActiveStation.FireMessage();
    }

    public void TargetAngel(float angel)
    {
        ActiveStation.SetAngel(angel);
    }

}
