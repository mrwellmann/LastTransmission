using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalScript : MonoBehaviour {

    public float transmissionSpeed = 1.5f;

    public float lifeTime = 1.5f;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * transmissionSpeed;
    }

    private void FixedUpdate()
    {
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime < 0)
        {
            Destroy(this.gameObject);
            GameOver();
        }
        // if collided with Planet -> Game Over
        // if collided with Station -> New Station is active 
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Collider: " + col.gameObject.tag);
        if (col.gameObject.tag == "Transmitter")
        {
            col.gameObject.GetComponentInParent<TransmitterScript>().IsActive = true;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag != "Gazing")
        {
            Debug.Log("Transmission failed. Game Over.");
            GameOver();
            // Game Over
        }
    }

    private void GameOver()
    {
        TransmitterStationControll controll = GameObject.FindObjectOfType<TransmitterStationControll>();
        if (controll && !controll.Hololens)
        {
            GameObject.FindObjectOfType<GameManagerScript>().GameOver();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
