using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, z;
    float speed = 1.1f;

    Quaternion characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;
    
    bool cursorLock = true;

    void Start()
    {
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        characterRot *= Quaternion.Euler(0, xRot, 0);
        transform.localRotation = characterRot;


        UpdateCursorLock();
    }

    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        transform.position += transform.forward * z + transform.right * x;
    }


    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if(Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
