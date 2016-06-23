using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IInventory {
    void addItem(Item item);
    void addItemById(int id);
    IItemData getItemDataInSlot(int slot);
    bool isSlotEmpty(int slot);
}
