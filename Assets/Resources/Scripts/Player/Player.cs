using UnityEngine;
using System.Collections;

public class Player {

	private Inventory inventory;
    private NavMeshAgent nav;
    private PlayerManager playerManager;

    public Player(PlayerManager playerManager) {
        this.playerManager = playerManager;
        nav = this.playerManager.GetComponent<NavMeshAgent>();
		inventory = this.playerManager.GetComponent<Inventory> ();
    }

    public void setDestinacion(Vector3 destination) {
        nav.SetDestination(destination);
    }

	public void addItemToInventoryById(int itemId) {
		inventory.addItemById(itemId);
	}
}
