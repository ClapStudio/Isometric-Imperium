using UnityEngine;
using System.Collections;

public class TreeParts : MonoBehaviour {

    private Rigidbody rb;
    private float speed;

    public float startFrames;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

        speed = 0.05f;

        startFrames = 120;
	}
	
	// Update is called once per frame
	void Update () {

        rb.AddForce(transform.forward * speed);

        startFrames--;

        //if (startFrames <= 0) Destroy(this);

	}
}
