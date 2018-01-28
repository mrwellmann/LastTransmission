using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterScript : MonoBehaviour {

    public GameObject TransmitterAntenna;

    public GameObject Signal;

    public AudioClip sendSignal;

    public AudioClip receiveSignal;

    public float turnVelocity = 2.0f;

    private Renderer _stationRenderer;

    private bool _isActive;
    public bool IsActive { get
        {
            return _isActive;
        }
        set {
            if (value == _isActive)
            {
                return;
            }
            _isActive = value;
            TransmitterAntenna.SetActive(value);

            if (value)
            {
                GetComponent<AudioSource>().PlayOneShot(receiveSignal);
            }
            {
                GetComponent<AudioSource>().PlayOneShot(sendSignal);
            }
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
    void Awake () {
        _stationRenderer = transform.Find("StationObject/Station").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update () {

                  Material mat = _stationRenderer.material;

            float emission = Mathf.PingPong(Time.time, 1.0f);

        
            Color baseColor =  IsActive ? Color.green : Color.red;

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
	}

}
