using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    private Transform сamera;
    private Transform parent;

    private Vector3 localRotation;
    private float cameraDistance = 50f;

    private float mouseSensitivity = 4f;
    private float scrollSensitvity = 2f;
    private float orbitDampening = 10f;
    private float scrollDampening = 6f;

    private bool cameraEnable;
    private bool isMousePressed;
    

    void Start()
    {
        сamera = transform;
        parent = transform.parent;
    }

    public void SwitchCameraEnable(bool enable)
    {
        cameraEnable = enable;
    }

    void LateUpdate()
    {   
        if (cameraEnable && Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }
        if (isMousePressed)
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

                if (localRotation.y < 0f)
                    localRotation.y = 0f;
                else if (localRotation.y > 90f)
                    localRotation.y = 90f;
            }
            
            Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
            parent.rotation = Quaternion.Lerp(parent.rotation, QT, Time.deltaTime * orbitDampening);

        }

        if (cameraEnable &&  Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitvity;
            ScrollAmount *= (cameraDistance * 0.3f);
            cameraDistance += ScrollAmount * -1f;
            cameraDistance = Mathf.Clamp(cameraDistance, 1.5f, 100f);
        }
        if (сamera.localPosition.z != cameraDistance * -1f)
        {
            сamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(сamera.localPosition.z, cameraDistance * -1f, Time.deltaTime * scrollDampening));
        }
    }
}