using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerBehavoiour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            gateFlag = true;
        }
        if (gateFlag == true)
        {
            popup.alpha = 1f;
            countDown -= Time.deltaTime;
        }
        if (countDown <= 0f)
        {
            gateFlag = false;
            countDown = 3f;
            popup.alpha = 0f;
        }
    }


    private Color colorA =  Color.blue;
    private bool gateFlag = false;
    private float countDown = 3f;
    public TextMeshProUGUI popup;
        
    void OnTriggerEnter(Collider gate)
    {
        Renderer render = GetComponent<Renderer>();
        colorA = render.material.color;
        render.material.color = Color.green;
        gateFlag = true;
    }


    void OnTriggerExit(Collider gate)
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = colorA;
    }
}
