using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoManager : MonoBehaviour
{

    private Vector3 startPos;
    private int velocidad = 3;

    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(startPos.x + Mathf.Sin(Time.time * velocidad), startPos.y , startPos.z);
    }
}
