using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class looking : MonoBehaviour
{
    public float touchSensitif = 100f;
    public Transform playerBody;

    public TouchFild tochScreen;

    

    float xRotation = 0f;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = tochScreen.TouchDist.x* touchSensitif * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * touchSensitif * Time.deltaTime;

        

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30, 30f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);  


    }
}
