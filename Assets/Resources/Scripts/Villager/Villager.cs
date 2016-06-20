using UnityEngine;

public class Villager {

    private Inventory inventory;
    private float gatherSpeed;
    private Resource resourceAssigned;
    public NavMeshAgent nav;
    private Resource destination;
    
    private bool onDestination;
    private bool moving;
    private bool working;

    private bool needClearInventory;

    public Villager (VillagerManager villagerManager)
    {
        inventory = new Inventory(30f);
        gatherSpeed = 5f;
        onDestination = false;
        moving = false;
        working = false;
        needClearInventory = false;
        nav = villagerManager.GetComponent<NavMeshAgent>();
    }

    public void assignWork(Resource resource) {
        this.resourceAssigned = resource;
    }

    public bool isOnDestination() {
        return this.onDestination;
    }

    public bool isMoving() {
        return this.moving;
    }

    public Resource getResourceAssigned() {
        return this.resourceAssigned;
    }

    public Resource getDestination() {
        return this.destination;
    }

    public void setDestination(Resource destination) {
        this.destination = destination;
        working = false;
        nav.enabled = true;
        nav.SetDestination(this.destination.transform.position);
    }

    public bool isInventoryFull() {
        return inventory.isFull();
    }

    public bool isNeedClearInventory() {
        return needClearInventory;
    }

    public void setNeedClearInventory(bool needClearInventory) {
        this.needClearInventory = needClearInventory;
    }

    public void destinationArrived() {
        onDestination = true;
        nav.enabled = false;
        if (destination == resourceAssigned) {
            working = true;
        }
    }

    public bool isWorking() {
        return this.working;
    }

    public void addToInventory(float quantity) {
        inventory.addQuanity(quantity);
    }

    public float getInventorySpace() {
        return inventory.getActualQuantity();
    }

    public float getMaxInventorySpace() {
        return inventory.getMaxCapacity();
    }
}
