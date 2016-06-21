using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {

    public string itemName;
    public int itemId;
    public string itemDesc;
    public Texture2D itemIcon;
    public ItemType itemType;

    public enum ItemType {
        Weapon,
        Consumible,
        Quest,
		Material
    }
}
