using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Inventory))]
public class PlayerManager : MonoBehaviour {

    public enum PlayerStates { AWAKE, IDLE, MOVING, GATHERING, DAMAGED, CRAFTING, DEAD }

    [Header("States")]
    public PlayerStates state;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    public Player player;

    public Animator anim;

    [Header("Particles")]
    public ParticleSystem clickOnFX;

    private Inventory inventory;

    // Use this for initialization
    void Start () {

        inventory = GetComponent<Inventory>();

        player = new Player(this);

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case PlayerStates.AWAKE:
                AwakeBehaviour();
                break;
            case PlayerStates.IDLE:
                IdleBehaviour();
                break;
            case PlayerStates.MOVING:
                MovingBehaviour();
                break;
            case PlayerStates.GATHERING:
                GatheringBehaviour();
                break;
            case PlayerStates.DAMAGED:
                DamagedBehaviour();
                break;
            case PlayerStates.CRAFTING:
                CraftingBehaviour();
                break;
            case PlayerStates.DEAD:
                DeadBehaviour();
                break;
         
        }

        if (Input.GetMouseButtonDown(0))
        {
            checkObjectSelected();
        }
        
	}

    // Sets
    public void setAwake()
    {
        anim.SetBool("isWalking", false);
    }

    public void setIdle()
    {
        anim.SetBool("isWalking", false);
    }

    public void setMoving()
    {
        anim.SetBool("isWalking", true);


    }
    public void setGathering()
    {

    }

    public void setDamaged()
    {

    }

    public void setCrafting()
    {

    }

    public void setDead()
    {

    }

    // Behaviours
    private void AwakeBehaviour()
    {
        setIdle();                                                                
    }


    private void IdleBehaviour()
    {
                                                                 
    }

    private void MovingBehaviour()
    {

    }

    private void GatheringBehaviour()
    {

    }

    private void DamagedBehaviour()
    {
                                                              
    }

    private void CraftingBehaviour()
    {
                                                              
    }

    private void DeadBehaviour()
    {
        
    }

    private void checkObjectSelected()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

			switch (hit.transform.tag) {
			case "Unselectionable":
					player.setDestinacion(hit.point);

					anim.SetBool("isWalking", true);

					clickOnFX.transform.position = hit.point;

					clickOnFX.Play();
					break;
			case "Drop":
                    inventory.addItemById(hit.transform.GetComponent<Drop>().itemId);
				break;
			}
        }
    }
}
