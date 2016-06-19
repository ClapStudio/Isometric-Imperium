using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    private TreeManager treeScript;
    public float woodResource;

    // Use this for initialization
    void Start () {

        woodResource = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            checkObjectSelected();
        }
        
	}

    private void checkObjectSelected()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag != "Unselectionable")
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }
}
