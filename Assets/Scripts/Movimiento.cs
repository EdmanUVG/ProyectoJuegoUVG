using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public GameObject sp;
    public GameObject prefabSphere;
    private GameObject objectSphere;

    public GameObject pauseMenu;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if(prefabSphere && sp)
        {
            objectSphere = Instantiate(prefabSphere, sp.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            myPause();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if(Input.GetKeyDown(KeyCode.Return) && !objectSphere)
        {
            objectSphere = Instantiate(prefabSphere, sp.transform.position, Quaternion.identity);
        }

        RaycastHit hitInfo;

        if(Physics.Raycast(transform.position, Vector3.down, out hitInfo, 3.0f ))
        {

           
            Debug.DrawRay(transform.position, Vector3.down * 3, Color.red );

            if(hitInfo.collider.gameObject.CompareTag("enemy"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
            
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitinfo;

            if(Physics.Raycast(myRay, out hitinfo, 10.0f ))
            {
                if(hitinfo.collider.gameObject.CompareTag("PowerUp"))
                {
                    Destroy(hitinfo.collider.gameObject);
                }
            }
        }
        
    }

    public void myPause()
    {
        if(isPaused)
        {
            if (pauseMenu) pauseMenu.SetActive(false);
                Time.timeScale = 1.0f;
           
        } else
        {
            if (pauseMenu) pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
        }

        isPaused = !isPaused;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
