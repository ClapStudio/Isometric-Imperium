using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour, IInventory {
	
	private List<Item> inventory = new List<Item>();
    public int inventorySize;
    public int slotsX, slotsY;
    public GUISkin slotSkin;

    private int maxSlotsRow = 5;
    public bool showInventory;
	private ItemDB itemDB;

	// Use this for initialization
	void Start () {
        itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDB>();
		for(int i = 0; i < inventorySize; i++) {
            inventory.Add(new Item());
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Inventory")) {
            showInventory = !showInventory;
        }
	}

	void OnGUI() {
        GUI.skin = slotSkin;

        if (showInventory) {
            drawInventory();
        }
	}

    void drawInventoryFake() {
        int slotPosition = 0;
        for(int x = 0; x < slotsX; x++) {
            for (int y = 0; y < slotsY; y++) {
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
                GUI.Box(slotRect, x.ToString() + ":" + y.ToString(), slotSkin.GetStyle("Slot"));

                slotPosition++;
            }
        }
    }

    void drawInventory() {
        int row = 0;
        int column = 0;
        
        for(int i = 0; i < inventory.Count; i++) {
            Rect slotRect = new Rect(row * 60, column * 60, 50, 50);
            GUI.Box(slotRect, "", slotSkin.GetStyle("Slot"));

            if (inventory[i].itemName != null) {
                GUI.DrawTexture(slotRect, inventory[i].itemIcon);
            }

            row++;
            if(row == maxSlotsRow) {
                row = 0;
                column++;
            }
        }
    }

    void addItem(Item item) {
        for(int i = 0; i < inventory.Count; i++) {
            if(inventory[i].itemName == null) {
                inventory[i] = item;
                break;
            }
        }
    }

    public void addItemById(int itemId) {
        Item itemResult = itemDB.items.Find(item => item.itemId == itemId);
        addItem(itemResult);
    }
}
