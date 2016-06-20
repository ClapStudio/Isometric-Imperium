using UnityEngine;
using System.Collections;

public class Player {

    private Inventory inventory;
    public NavMeshAgent nav;
    private PlayerManager playerManager;

    public Player(PlayerManager playerManager) {
        this.playerManager = playerManager;
        nav = this.playerManager.GetComponent<NavMeshAgent>();
    }

    public void setDestinacion(Vector3 destination) {
        nav.SetDestination(destination);
    }
}
