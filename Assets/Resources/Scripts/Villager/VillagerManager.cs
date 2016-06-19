using UnityEngine;
using System.Collections;

public class VillagerManager : MonoBehaviour {

    public float inventoryCapacity;
    public float gatherSpeed;

    public float currentInventorySpace;
    private GameObject target;
    private TreeManager targetManager;
    private bool isWorking;
   

    // Use this for initialization
    void Start () {
        inventoryCapacity = 30f;
        currentInventorySpace = 0;
        gatherSpeed = 5;

        isWorking = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            target = GameObject.FindGameObjectWithTag("Tree");
            targetManager = target.GetComponent<TreeManager>();
            //TODO: check if villager has arrived to his targed
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
        float resourceObtainedQuantity = targetManager.gather(gatherSpeed);
        currentInventorySpace += resourceObtainedQuantity;

        if (currentInventorySpace >= inventoryCapacity || targetManager.getCurrentSourceQuantity() <= 0)
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
