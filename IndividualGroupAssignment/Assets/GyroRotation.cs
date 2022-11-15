using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializeGyro());
    }

    IEnumerator InitializeGyro()
    {
        Input.gyro.enabled = true;
        yield return null;
        Debug.Log(Input.gyro.attitude); // attitude has data now
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Rotation: " + Input.acceleration);
        transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        //transform.position += Input.gyro.rotationRateUnbiased;
        transform.position += transform.forward * Input.gyro.rotationRateUnbiased.magnitude * 1f;
    }
}
