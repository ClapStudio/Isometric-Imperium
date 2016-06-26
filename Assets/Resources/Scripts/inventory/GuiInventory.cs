using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiInventory : MonoBehaviour {

    public Inventory inventory;
    public GameObject slotPrefab;
    public GUISkin inventorySkin;

	// Use this for initialization
	void Start () {
        drawInventory();
        updateInventory();

    }
	
	// Update is called once per frame
	void Update () {
        updateInventory();
    }

    void OnGUI() {
        //GUI.skin = inventorySkin;
        
        //drawInventory();

    }

    void drawInventory() {
        //Create all Slots Prefabs
        for (int i = 0; i < inventory.getInventorySize(); i++) {
            Instantiate(slotPrefab).transform.SetParent(transform);
        }
    }

    void updateInventory() {
        for (int i = 0; i < inventory.getInventorySize(); i++) {
            if (!inventory.isSlotEmpty(i)) { //If the current slot have an item, draw it
                IItemData itemData = inventory.getItemDataInSlot(i);
                transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = itemData.item.icon;

                if (itemData.amount > 1) { //If it has more than 1 in the same slot, draw the quantity
                    transform.GetChild(i).GetChild(0).GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text = itemData.amount.ToString();
                } else { //Hide quantity text
                    transform.GetChild(i).GetChild(0).GetChild(0).gameObject.SetActive(false);
                }

            } else { //Hide sprite if there is no item
                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
