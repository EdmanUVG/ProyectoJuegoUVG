using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    private void OnMouseDown()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
