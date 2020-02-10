using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarStatus : MonoBehaviour
{

    public Text nombre;

    // Update is called once per frame
    void update()
    {
        Vector3 healthbarPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        nombre.transform.position = healthbarPosition;

     
    }

}
