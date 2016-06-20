using UnityEngine;
using System.Collections;

public class VillagerManager : MonoBehaviour {

    private Villager villager;
    
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    // Use this for initialization
    void Start () {
        villager = new Villager(this);

    }
	
	// Update is called once per frame
	void Update () {
        villagerAction();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == villager.getDestination().gameObject)
        {
            Debug.Log("HIT TARGET");
            villager.destinationArrived();
        }
    }

    public void assignResource(Resource resource) {
        villager.assignWork(resource);
    }

    private void villagerAction() {
        //Si no tiene destino, asignarle.
        if(villager.getDestination() == null) {
            if(!villager.isNeedClearInventory() && villager.getResourceAssigned() != null) {
                villager.setDestination(villager.getResourceAssigned());
            } else if(!villager.isNeedClearInventory() && villager.getResourceAssigned() != null) {
                villager.setDestination(GameObject.FindGameObjectWithTag("Town Hall").GetComponent<Resource>());
            }
        }

        if (villager.isOnDestination() && !villager.isNeedClearInventory() && villager.getDestination() != null) {
            float gatherResult = villager.getDestination().gather(5);
            villager.addToInventory(gatherResult);

            if(villager.isInventoryFull()) {
                villager.setNeedClearInventory(true);
            }
        }

        if(villager.isNeedClearInventory()) {
            villager.setDestination(GameObject.FindGameObjectWithTag("Town Hall").GetComponent<Resource>());
        }       
    }

}
