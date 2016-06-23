using UnityEngine;
using System.Collections;

public class OnMouseOverObject : MonoBehaviour {

    private bool isClick;
    private bool isOver;
    public ParticleSystem mouseOverFX;
    public ParticleSystem mouseClickFX;

    // Use this for initialization
    void Start () {

        isClick = false;
        isOver = false;
        mouseOverFX.Stop();

    }
	
	// Update is called once per frame
	void Update () {

        if (isOver)
        {
            mouseOverFX.Play(true);
            mouseClickFX.Stop(true);
        }

        if (isOver && isClick)
        {
            mouseOverFX.Stop(true);
            mouseClickFX.Play(true);
        }

        else
        {
            mouseOverFX.Stop(true);
            mouseClickFX.Stop(true);
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

    void OnMouseDown()
    {
        if (!isClick)
        {
            isClick = true;
        }

    }
}
