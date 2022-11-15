using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehavoiour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private Color colorA =  Color.blue;
        
    void OnTriggerEnter(Collider gate)
    {
        Renderer render = GetComponent<Renderer>();
        colorA = render.material.color;
        render.material.color = Color.green;
    }


    void OnTriggerExit(Collider gate)
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = colorA;
    }
}
