using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    public int treeHealth;

    public GameObject logs;
    private GameObject tree;

    public GameObject treeTop01;
    public GameObject treeTop02;
    public GameObject treeTop03;
    public GameObject treeWood;
    
    // Use this for initialization
    void Start () {

        tree = this.gameObject;
        treeHealth = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (treeHealth <= 0)
        {
           DestroyTree();
        }
	
	}

    void DestroyTree()
    {
        Instantiate(treeTop01, tree.transform.position, Quaternion.identity);
        Instantiate(treeTop02, tree.transform.position, Quaternion.identity);
        Instantiate(treeTop03, tree.transform.position, Quaternion.identity);
        Instantiate(treeWood, tree.transform.position, Quaternion.identity);

        Destroy(tree);

        Instantiate(logs, tree.transform.position, Quaternion.identity);

    }
}
