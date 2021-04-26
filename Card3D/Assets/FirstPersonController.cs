using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private static FirstPersonController sharedInstance;
    [Header("Mouse Lock")]
    public bool isMouseLocked;
    [Header("Camera Field of View")]
    public bool isFieldOfViewEnabled;
    public float cameraFieldOfViewMin;
    public float cameraFieldOfViewMax;
    public float fieldOfViewIncrement;
    [Header("Camera Rotate X Setting")]
    public float cameraRotateMax;
    public float cameraRotateMin;
    [Header("Mouse Smoothing Value")]
    public float mouseSmooth;

    //public GameObject target;
   


    private Camera m_camera;
    private float m_fieldOfView;
    private Transform m_parent;
    private float m_mouseX;
    private float m_mouseY;
    private float m_rotateX;
    private float m_mouseScroll;
    //private Rigidbody rb;

    Vector3 Vec;
    private void Awake()
    {
        sharedInstance = this;
        m_camera = Camera.main;
        m_parent = transform.parent;
        //rb = m_parent.GetComponent<Rigidbody>();
        if(m_camera != null)
        {
            m_fieldOfView = m_camera.fieldOfView;
        }
        MouseLock();
    }

    public static FirstPersonController GetSharedInstance()
    {
        return sharedInstance;
    }
    // Update is called once per frame
    void Update()
    {
        MouseInputs();
        RotatePlayerY();
        CameraRotateX();
        CameraZoom();
        //target.transform.localPosition = Quaternion.Euler(m_camera.transform.position.x, 0, 0);
        //target.transform.forward = ((m_camera.transform.position - Vector3.up * m_camera.transform.position.y) - target.transform.position).normalized;
    }

    private void MouseInputs()
    {
        m_mouseX = Input.GetAxis("Mouse X") * mouseSmooth;
        m_mouseY = Input.GetAxis("Mouse Y") * mouseSmooth;
        m_mouseScroll = Input.GetAxis("Mouse ScrollWheel");
    }

    private void RotatePlayerY()
    {
        m_parent.Rotate(Vector3.up * m_mouseX);
    }
    private void CameraRotateX()
    {
        m_rotateX -= m_mouseY;
        m_rotateX = Mathf.Clamp(m_rotateX, cameraRotateMin, cameraRotateMax);
        m_camera.transform.localRotation = Quaternion.Euler(m_rotateX, 0f, 0f);
    }
    private void MouseLock()
    {
        if (isMouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
        Cursor.lockState = CursorLockMode.None;
    }
    private void CameraZoom()
    {
        if (isFieldOfViewEnabled)
        {
            if (m_mouseScroll > 0.0f)
            {
                if(m_fieldOfView + fieldOfViewIncrement >= cameraFieldOfViewMin &&
                    m_fieldOfView + fieldOfViewIncrement <= cameraFieldOfViewMax)
                {
                    m_fieldOfView += fieldOfViewIncrement;
                    m_camera.fieldOfView = m_fieldOfView;
                }
            }
            if (m_mouseScroll < 0.0f)
            {
                if (m_fieldOfView - fieldOfViewIncrement >= cameraFieldOfViewMin &&
                    m_fieldOfView - fieldOfViewIncrement <= cameraFieldOfViewMax)
                {
                    m_fieldOfView -= fieldOfViewIncrement;
                    m_camera.fieldOfView = m_fieldOfView;
                }
            }
        }
    }
}
