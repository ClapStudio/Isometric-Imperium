using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Source: https://unity3d.com/es/learn/tutorials/modules/intermediate/live-training-archive/panels-panes-windows
public class FocusPanel : MonoBehaviour, IPointerDownHandler {

    private RectTransform panel;

    void Awake() {
        panel = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData data) {
        panel.SetAsLastSibling();
    }

}