using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Source: https://unity3d.com/es/learn/tutorials/modules/intermediate/live-training-archive/panels-panes-windows
public class ResizePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler {

    public Vector2 minSize;
    public Vector2 maxSize;
    public Texture2D resizeImage;

    private RectTransform rectTransform;
    private Vector2 currentPointerPosition;
    private Vector2 previousPointerPosition;
    
    private CursorMode cursorMode = CursorMode.Auto;
    private bool dragging;
    private bool over;

    void Awake() {
        rectTransform = transform.parent.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData data) {
        dragging = true;
        rectTransform.SetAsLastSibling();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, data.position, data.pressEventCamera, out previousPointerPosition);
    }

    public void OnPointerUp(PointerEventData data) {
        dragging = false;
        if (!over) {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    public void OnDrag(PointerEventData data) {
        if (rectTransform == null)
            return;

        Vector2 sizeDelta = rectTransform.sizeDelta;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, data.position, data.pressEventCamera, out currentPointerPosition);
        Vector2 resizeValue = currentPointerPosition - previousPointerPosition;

        sizeDelta += new Vector2(resizeValue.x, -resizeValue.y);


        sizeDelta = new Vector2(
            Mathf.Clamp(sizeDelta.x, minSize.x, maxSize.x),
            Mathf.Clamp(sizeDelta.y, minSize.y, maxSize.y)
            );
        
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeDelta.x);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sizeDelta.y);

        previousPointerPosition = currentPointerPosition;
    }

    //Pointer image change
    public void OnPointerEnter(PointerEventData eventData) {
        over = true;
        Cursor.SetCursor(resizeImage, Vector2.zero, cursorMode);
        
    }

    public void OnPointerExit(PointerEventData eventData) {
        over = false;
        if (!dragging) {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}