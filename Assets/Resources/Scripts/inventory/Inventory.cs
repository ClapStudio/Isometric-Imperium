using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public List<Item> inventory = new List<Item>();

	private ItemDB itemDB;

	// Use this for initialization
	void Start () {
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDB>();
		Debug.Log (itemDB);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addItemById(int itemId) {
		Item itemResult = itemDB.items.Find(item => item.itemId == itemId);
		inventory.Add(itemResult);
	}

	void OnGUI() {
		for (int i = 0; i < inventory.Count; i++) {
			GUI.Label (new Rect (10, 10, 200, 50), inventory [i].itemName);
		}
	}
}
