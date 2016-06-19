using UnityEngine;
using System.Collections;

public class VillagerManager : MonoBehaviour {

    public float inventoryCapacity;
    public float gatherSpeed;

    public float currentInventorySpace;
    private GameObject objectWorkingOn;
    private TreeManager targetManager;
    private bool isWorking;

    private GameObject target;
    private bool isMoving;

    private NavMeshAgent nav;


    // Use this for initialization
    void Start () {
        inventoryCapacity = 30f;
        currentInventorySpace = 0;
        gatherSpeed = 5;

        isWorking = false;
        isMoving = false;

        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            objectWorkingOn = GameObject.FindGameObjectWithTag("Tree");
            targetManager = objectWorkingOn.GetComponent<TreeManager>();
            target = GameObject.FindGameObjectWithTag("Tree");
            //TODO: check if villager has arrived to his targed
            nav.SetDestination(target.transform.position);
            isMoving = true;
        }

        if(isMoving)
        {
            move();
        }

        if (isWorking)
        {
            work();
        }
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
}
