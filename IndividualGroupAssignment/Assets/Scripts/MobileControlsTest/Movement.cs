using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool isFlat = true;
    public Rigidbody carObject;


    void tiltControls()
    {
        Vector3 tilting = Input.acceleration;

        if (isFlat)
        {
            tilting = Quaternion.Euler(90, 0, 0) * tilting;
            carObject.AddForce(tilting);
            //  print("Ya its working");
            Debug.DrawRay(transform.position + Vector3.up, tilting, Color.cyan);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        carObject = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {



        tiltControls();


    }
}
