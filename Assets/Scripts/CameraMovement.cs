using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speedH = 2.0f;
    [SerializeField]
    private float speedV = 2.0f;
    [SerializeField]
    private float distance = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        }
    }
}
