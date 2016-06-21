using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public List<Item> inventory = new List<Item>();

	private ItemDB itemDB;

	// Use this for initialization
	void Start () {
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDB>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
