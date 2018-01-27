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
        }
        // if collided with Planet -> Game Over
        // if collided with Station -> New Station is active 
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Collider: " + col.gameObject.tag);
        if (col.gameObject.tag == "Transmitter")
        {
            col.gameObject.GetComponent<TransmitterScript>().IsActive = true;
            Destroy(this.gameObject);
        } else
        {
            // Game Over
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
