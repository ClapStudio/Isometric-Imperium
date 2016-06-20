using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform target;

    [Header("Rotation")]
    public float turnSpeed = 4f;

    [Header("Zoom")]
    public float minFov = 15f;
    public float maxFov = 90f;
    public float zoomSensibility = 10f;

    private Vector3 offset;
    private bool isControlCamera = false;


    void Start() {
        offset = new Vector3(target.position.x, target.position.y + 4f, target.position.z - 7f);

    }

    // Update is called once per frame
    void Update() {

        transform.position = target.position + offset;
        transform.LookAt(target.position);

        ckeckControls();

        if (isControlCamera) {
            cameraControl();
        }
    }

    private void ckeckControls() {
        //Camera rotation
        if (Input.GetMouseButtonDown(1)) {
            isControlCamera = true;
        }
        if (Input.GetMouseButtonUp(1)) {
            isControlCamera = false;
        }

        //Camera Zoom
        float fov = GetComponent<Camera>().fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * zoomSensibility;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }

    private void cameraControl() {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
    }

}