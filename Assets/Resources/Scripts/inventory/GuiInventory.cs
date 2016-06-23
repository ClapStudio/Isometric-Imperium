using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiInventory : MonoBehaviour {

    public Inventory inventory;
    public GUISkin inventorySkin;
    
    bool showInventory;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory")) {
            showInventory = !showInventory;
        }
    }

    void OnGUI() {
        GUI.skin = inventorySkin;

        if (showInventory) {
            drawInventory();
        }

    }

    void drawInventory() {
        int row = 0;
        int column = 0;

        //Estaria bien calcular este numero depeniendo el tamaño del inventario en la pantalla(En en caso que se pueda hacer la ventana mas grande)
        int maxSlotsRow = 5;

        for (int i = 0; i < inventory.getInventorySize(); i++) {

            Rect slotRect = new Rect(row * 60, column * 60, 50, 50);
            GUI.Box(slotRect, "" , inventorySkin.GetStyle("Slot"));

            if (!inventory.isSlotEmpty(i)) {
                IItemData itemData = inventory.getItemDataInSlot(i);
                GUI.DrawTexture(slotRect, itemData.item.icon);
                if(itemData.amount > 1) {
                    Rect labelRect = new Rect(row * 60, column * 60, 20, 20);
                    GUI.Box(labelRect, itemData.amount.ToString());
                }
            }
            
            row++;
            if (row == maxSlotsRow) {
                row = 0;
                column++;
            }
        }
    }
}
