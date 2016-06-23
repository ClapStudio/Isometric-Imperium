using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour {

    
    List<ItemData> inventory = new List<ItemData>();
    int inventorySize = 25;
    int maxSlotsRow = 5;
	ItemDB itemDB;

	// Use this for initialization
	void Start () {
        itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDB>();
		for(int i = 0; i < inventorySize; i++) {
            inventory.Add(new ItemData());
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void addItem(Item item) {

        //Check if is stackeable and exists
        if(item.stackable && containsItem(item)) {
            getItemData(item).amount += 1;
        } else {
            //Check if incentory is full

            if(inventory.Any(itemData => itemData.item == null)) {
                //Find the first empty slot and add the new item to it
                int slotPositionEmpty = inventory.FindIndex(itemData => itemData.item == null);
                inventory[slotPositionEmpty] = new ItemData(item, 1);
            } else {
                //Inventory is full, throw Exception
                throw new InventoryFullException();
            }
        }
    }

    public void addItemById(int itemId) {
        Item itemResult = itemDB.items.Find(item => item.id == itemId);
        addItem(itemResult);
    }

    IItemData getItemData(Item itemToFind) {
        return inventory.Find(itemData => itemData.item.id == itemToFind.id);
    }

    public IItemData getItemDataInSlot(int slot) {
        return inventory[slot];
    }

    public bool isSlotEmpty(int slot) {
        return inventory[slot].item == null;
    }

    public int getInventorySize() {
        return inventorySize;
    }


    bool containsItem(Item itemToCheck) {
        return inventory.Any(itemData => itemData.item != null && itemData.item.id == itemToCheck.id);
    }
}
