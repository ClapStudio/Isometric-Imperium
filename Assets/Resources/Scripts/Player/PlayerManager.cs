﻿using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    private Player player;

    public ParticleSystem clickOnFX;

    // Use this for initialization
    void Start () {
        player = new Player(this);
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
            if (hit.transform.tag == "Unselectionable")
            {
                player.setDestinacion(hit.point);

                clickOnFX.transform.position = hit.point;

                clickOnFX.Play();

            }
        }
    }
}
