using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemData : IItemData {
    int _amount;
    Item _item;

    public int amount {
        get { return _amount; }
        set { _amount = value; }
    }
    public Item item {
        get { return _item; }
        set { _item = value; }
    }
    public ItemData() { }

    public ItemData(Item item, int amount) {
        this.item = item;
        this.amount = amount;
    }
}
