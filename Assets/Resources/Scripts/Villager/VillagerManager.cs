using UnityEngine;
using System.Collections;

public class VillagerManager : MonoBehaviour {

    private Villager villager;

    public float inventoryCapacity;
    public float gatherSpeed;

    public float currentInventorySpace;
    private GameObject objectWorkingOn;
    private Resource resource;
    private bool isWorking;

    private GameObject target;
    private bool isMoving;

    private NavMeshAgent nav;

    // Use this for initialization
    void Start () {
        villager = new Villager(this);

    }
	
	// Update is called once per frame
	void Update () {
        villager.action();
    }

    private void startWork()
    {
        Debug.Log("Start Work.");
        isWorking = true;
    }

    private void endWork()
    {
        Debug.Log("End Work.");
        target = GameObject.FindGameObjectWithTag("Town Hall");
        move();
        nav.SetDestination(target.transform.position);
        isWorking = false;
        isMoving = true;
    }

    /*private void work()
    {
        Debug.Log("Working.");
        float resourceObtainedQuantity = resource.gather(gatherSpeed);
        currentInventorySpace += resourceObtainedQuantity;

        if (currentInventorySpace >= inventoryCapacity || resource.getCurrentSourceQuantity() <= 0)
        {            
            endWork();
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT!");
        if (other.gameObject == target)
        {
            isMoving = false;
            startWork();
            nav.enabled = false;
        }
    }

    private void move()
    {
        nav.enabled = true;
    }

    public void assignResource(Resource resource) {
        villager.assignWork(resource);
    }
}
