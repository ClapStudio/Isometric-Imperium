using UnityEngine;
using System.Collections;

public class OnMouseOverObject : MonoBehaviour {

    private bool isOver;
    public ParticleSystem mouseOverFX;

    // Use this for initialization
    void Start () {

        isOver = false;
        mouseOverFX.Stop();

    }
	
	// Update is called once per frame
	void Update () {

        if (isOver)
        {

            mouseOverFX.Play(true);
        }

        else
        {
            mouseOverFX.Stop(true);
        }

    }

    void OnMouseOver()
    {

        if (!isOver)
        {
            isOver = true;
        }
    }

    void OnMouseExit()
    {
        if (isOver)
        {
            isOver = false;
        }
    }
}
