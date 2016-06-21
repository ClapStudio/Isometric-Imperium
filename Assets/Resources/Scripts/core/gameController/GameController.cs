using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GameController : MonoBehaviour {
    
    public List<Item> items;

	// Use this for initialization
	void Start () {
        createItems();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void loadItems() {
        string jsonItems = null;
        jsonItems = File.ReadAllText(Application.dataPath + "/Resources/Database/Items.json");
        items = JsonUtility.FromJson<List<Item>>(jsonItems);
    }

    private void createItems() {
        items.Add(new Item());
		string itemsJson = JsonUtility.ToJson(items);
        File.WriteAllText(Application.dataPath + "/Resources/Database/Items.json", itemsJson);
    }
}
