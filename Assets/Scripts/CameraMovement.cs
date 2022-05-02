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
    [SerializeField]
    private Vector3 newposition = new Vector3(0, 0, -2);
    [SerializeField]
    private float zoomOutTime = 60f;

    [SerializeField]
    private float angle = 180f;
    [SerializeField]
    private float rotationTime = 60f;
    private Quaternion desiredRotQ;

    [SerializeField]
    private float rotateAngle = 180f;

    // Start is called before the first frame update
    void Start()
    {
        //DiscoRotation();
        StartCoroutine(SmoothTransition(transform.position, newposition, zoomOutTime));
    }

    void Manual()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        }
    }


    IEnumerator SmoothTransition(Vector3 startPosition, Vector3 endPosition, float seconds)
    {
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
        DiscoRotation();
    }

    void DiscoRotation()
    {
        InvokeRepeating("InfinityAndBeyond", 0, rotationTime);


    }

    void InfinityAndBeyond()
    {
        
        var x = Random.Range(-1*rotateAngle, rotateAngle);
        var y = Random.Range(-1*rotateAngle, rotateAngle);
        var z = Random.Range(-1 * rotateAngle, rotateAngle);
        //generate angle
        desiredRotQ = Quaternion.Euler(x, y, z);
        StartCoroutine(RotateObject(rotationTime, desiredRotQ));
    }

    IEnumerator RotateObject(float time, Quaternion targetRotation)
    {
        float tParam = 0.0f;

        Quaternion currentRotation = transform.rotation;

        // Compares angles of two Quaternions
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {

            tParam += Time.deltaTime * (1 / time);

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, tParam);

            yield return null;
        }

        // Hard lock the rotation
        transform.rotation = targetRotation;

    }

}