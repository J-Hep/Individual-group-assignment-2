using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneShake : MonoBehaviour
{
    public float shakeDetectionThreshold = 3.6f;
    public float minShakeInterval = 0.2f;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    public float shakeForce = 15f;
    public Rigidbody carRB;

    Gyroscope _gyro;

    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(shakeDetectionThreshold, 2);
        _gyro = Input.gyro;
        _gyro.enabled = true;

    }

    void Update()
    {
        Debug.Log(_gyro.attitude);
        Debug.Log(Input.gyro.attitude + " input");
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold
            && Time.unscaledTime >= timeSinceLastShake + minShakeInterval)
        {
            MoveCar(Input.acceleration);
            timeSinceLastShake = Time.unscaledTime;
        }
    }

    public void MoveCar(Vector3 deviceAccel)
    {
        Debug.Log("Shake: " + deviceAccel * shakeForce);
        carRB.AddForce(transform.forward * deviceAccel.magnitude * shakeForce);
    }
}
