using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterScript : MonoBehaviour {

    public GameObject TransmitterAntenna;

    public GameObject Signal;

    public float turnVelocity = 2.0f;

    private bool _isActive;
    public bool IsActive { get
        {
            return _isActive;
        }
        set {
            _isActive = value;
            TransmitterAntenna.SetActive(value);
        }
    }

    public void Turn(float delta)
    {
        TransmitterAntenna.transform.Rotate(Vector3.up, delta * turnVelocity);
    }

    public void SetAngel(float angel)
    {
        TransmitterAntenna.transform.eulerAngles = new Vector3 (TransmitterAntenna.transform.eulerAngles.x, angel, TransmitterAntenna.transform.eulerAngles.z);
    }

    public void FireMessage()
    {
        if (GameObject.FindGameObjectsWithTag("Signal").Length > 0)
        {
            return;
        }
        var stationPos = transform.Find("StationObject").gameObject.transform.position;
        var stationRot = transform.Find("StationObject/Antenna").gameObject.transform.rotation;
        GameObject signalClone = Instantiate(Signal, stationPos, stationRot);
        IsActive = false;
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update () {
		
	}

}
