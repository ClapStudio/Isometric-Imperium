using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    public int treeHealth;

    public GameObject logs;
    private GameObject tree;
    public float speed;

    private Rigidbody rb;



	// Use this for initialization
	void Start () {

        tree = this.gameObject;
        rb.isKinematic = true;
        rb = this.GetComponent<Rigidbody>();

        treeHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (treeHealth <= 0)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * speed);
            DestroyTree();
        }
    }

    void DestroyTree()
    {
        //yield return new WaitForSeconds(5);
        Destroy(tree);

        Instantiate(logs, tree.transform.position, Quaternion.identity);
    }
}
