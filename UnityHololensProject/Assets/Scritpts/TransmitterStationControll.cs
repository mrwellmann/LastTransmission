using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterStationControll : MonoBehaviour {

    public GameObject[] TransmitterStations;
    public bool Hololens = false;
    public TransmitterScript ActiveStation;
    public GazeableSystem GazeableSystem;

    private void Awake()
    {
        SetActiveStation(TransmitterStations[0].GetComponent<TransmitterScript>());
    }

    private void SetActiveStation(TransmitterScript activeStation)
    {
        ActiveStation = activeStation;
        if (GazeableSystem)
        {
            GazeableSystem.ActiveStation = ActiveStation;
        }
    }

    public void ActivateStation(int stationNo)
    {
        foreach(GameObject transmitter in TransmitterStations)
        {
            transmitter.GetComponent<TransmitterScript>().IsActive = false;
        }
        TransmitterStations[stationNo].GetComponent<TransmitterScript>().IsActive = true;
        SetActiveStation(TransmitterStations[stationNo].GetComponent<TransmitterScript>());
    }

    private void FixedUpdate()
    {
        foreach (GameObject transmitter in TransmitterStations)
        {
            if (transmitter.GetComponent<TransmitterScript>().IsActive)
            {
                SetActiveStation(transmitter.GetComponent<TransmitterScript>());
            }
        }
        
    }

    // Update is called once per frame
    void Update () {
         bool fire = Input.GetButton("FireMessage");
         float horizontal = Input.GetAxis("Horizontal");

        if (!Hololens)
        {
            if (horizontal != 0.0f)
            {
                ActiveStation.Turn(horizontal);
            }
        }


         if (fire)
         {
            ActiveStation.FireMessage();
         }
    }

    public void FireSignal(float angel)
    {
        ActiveStation.SetAngel(angel);
        ActiveStation.FireMessage();
    }

    public void TargetAngel(float angel)
    {
        ActiveStation.SetAngel(angel);
    }

}
