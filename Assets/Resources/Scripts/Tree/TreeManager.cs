using UnityEngine;
using System.Collections;

public class TreeManager : MonoBehaviour {

    public int outputSpeed;
    public int sourceQuantity;

    private int currentSourceQuantity;
    private bool isWorking;

    // Use this for initialization
    void Start () {
        outputSpeed = 5;
        sourceQuantity = 50;

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

    }
}
