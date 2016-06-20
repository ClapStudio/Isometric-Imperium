using UnityEngine;
using System.Collections;

public class TreeManager : Resource {

    public float sourceQuantity;

    private float currentSourceQuantity;

    // Use this for initialization
    void Start () {
        sourceQuantity = 50f;
        
        currentSourceQuantity = sourceQuantity;
    }
	
	// Update is called once per frame
	void Update () {

    }    

    public override float gather(float gatherSpeed)
    {
        float initialQuantity = currentSourceQuantity;
        currentSourceQuantity -= gatherSpeed * Time.deltaTime;

        return initialQuantity - currentSourceQuantity;
    }

    public float getCurrentSourceQuantity()
    {
        return currentSourceQuantity;
    }
}
