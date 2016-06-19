using UnityEngine;
using System.Collections;

public class TreeManager : MonoBehaviour {

    public float outputSpeed;
    public float sourceQuantity;

    private float currentSourceQuantity;
    private bool isWorking;

    // Use this for initialization
    void Start () {
        outputSpeed = 5f;
        sourceQuantity = 50f;

        isWorking = false;
        currentSourceQuantity = sourceQuantity;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            startWork();
        }

	    if(isWorking)
        {
            work();
        }
	}

    private void startWork()
    {
        Debug.Log("Start Work.");
        isWorking = true;
    }

    private void work()
    {
        Debug.Log("Working.");
        currentSourceQuantity -= outputSpeed * Time.deltaTime;
        Debug.Log("Remaining source quantity: " + currentSourceQuantity + ".");
        if(currentSourceQuantity <= 0)
        {
            endWork();
        }
    }

    private void endWork()
    {
        Debug.Log("End Work.");
        isWorking = false;
    }
}
