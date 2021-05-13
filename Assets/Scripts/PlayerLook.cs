using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] WallRun wallRun;

    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] Transform cam;
    [SerializeField] Transform orientation;

    float mouseX;
    float mouseY;

    public float multiplier = 1f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        //cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        if(!PauseMenu.isPaused)
        {
            MouseInput();
            cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt);
            //cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        
    }

    void MouseInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
