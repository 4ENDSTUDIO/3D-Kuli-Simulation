using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class looking : MonoBehaviour
{
    [Header("TouchScreen")]
    public float touchSensitif = 100f;
    public Transform playerBody;
    public TouchFild tochScreen;

    //[Header("Camera Follow")]
    //public Transform target;
    //public float smooting = 5f;
    //Vector3 offset;

    

    float xRotation = 0f;
    void Start()
    {
        //offset = transform.position - target.position;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        //Vector3 targetCanPos = target.position + offset;
        //transform.position = Vector3.Lerp(transform.position, targetCanPos, smooting * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

        TouchScreen();


    }

    public void TouchScreen()
    {
        float mouseX = tochScreen.TouchDist.x * touchSensitif * Time.deltaTime;
        float mouseY = tochScreen.TouchDist.y * touchSensitif * Time.deltaTime;



        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30, 30f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void CameraFollow()
    {

    }
}
