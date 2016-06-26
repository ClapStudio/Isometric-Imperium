using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TogglePanel : MonoBehaviour {

    public List<PanelInfo> panels;

    void Start() {
        foreach(PanelInfo panel in panels) {
            panel.target.SetActive(panel.showOnStart);
        }
    }

    void Update() {
        foreach (PanelInfo panel in panels) {
            if(Input.GetButtonDown(panel.inputName)) {
                panel.target.SetActive(!panel.target.activeSelf);
            }
        }
    }
}

[System.Serializable]
public class PanelInfo {
    public GameObject target;
    public bool showOnStart = false;
    public string inputName;
}