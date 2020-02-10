using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public GameObject pelota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
