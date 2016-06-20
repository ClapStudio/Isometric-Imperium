using UnityEngine;

public class Villager {

    private Inventory inventory;
    private float gatherSpeed;
    private Resource resourceAssigned;
    private NavMeshAgent nav;

    private bool isOnTarget;
    private bool isWalking;

    public Villager (VillagerManager villagerManager)
    {
        inventory = new Inventory(30f);
        gatherSpeed = 5f;
        isOnTarget = false;
        isWalking = false;
        nav = villagerManager.GetComponent<NavMeshAgent>();
    }
   
    public void action() {
        if(!isOnTarget && !isWalking && resourceAssigned != null) {
            nav.enabled = true;
            nav.SetDestination(resourceAssigned.transform.position);
        }
    }

    public void assignWork(Resource resource) {
        this.resourceAssigned = resource;
    }

}
