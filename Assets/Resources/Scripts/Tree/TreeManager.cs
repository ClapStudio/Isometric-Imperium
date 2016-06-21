using UnityEngine;
using System.Collections;

public class TreeManager : MonoBehaviour {

    public Shader normalShader;
    public Shader outlineShader;

    //private Renderer rendered;
    private bool isOver = false;

    // Use this for initialization
    void Start() {
        //rendered = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {

    }

    /*void OnMouseOver() {
        if(!isOver) {
            setShaderRecursive(transform, outlineShader);
            isOver = true;
        }
    }

    void OnMouseExit() {
        if (isOver) {
            setShaderRecursive(transform, normalShader);
            isOver = false;
        }
    }

    void setShaderRecursive(Transform parent, Shader shader) {
        Renderer parentRenderer = parent.GetComponent<Renderer>();

        if (parentRenderer) {
            parentRenderer.material.shader = shader;
        }

        foreach (Transform child in parent) {
            setShaderRecursive(child, shader);
        }
    }*/
}
