using UnityEngine;
using System.Collections;

public class WoodCounter : MonoBehaviour {

    public Text woodResourceShow;
    public int woodCounter;
    private PlayerManager playerManager;


    // Use this for initialization
    void Start () {

        woodResourceShow = GetComponent<Text>();
        woodCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {

        woodResourceShow.text = "" + woodCounter;

    }
}
