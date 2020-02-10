using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistola : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public Animator animator;

    public Text balas;

    private int enemigosMuertos = 0;

    public Text muertos;

    public Text txtReloading;

    //Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        balas.text = currentAmmo + " / " + maxAmmo;
        muertos.text = enemigosMuertos + " / 3";
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Disparar();
        }

    }

    void Disparar()
    {
        muzzleFlash.Play();

        balas.text = currentAmmo + " / " + maxAmmo;
  

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Se accede a la clase Target asignado a los ojetos que queremos destruir
            Target target = hit.transform.GetComponent<Target>();

            // Verifica que el objeto impactado no sea null
            if (target != null)
            {
                // Se manda ca cantidad de daño
                target.TakeDamage(damage);

                // Se verifica si el total de vida es cero o menor y devuelve un booleano
                if(target.esEnemigoMuerto)
                {
                    // Aumenta si es verdadero
                    enemigosMuertos++;
                    muertos.text = enemigosMuertos + " / 3";
                }
            }

            
            //  Si el objeto que impacta no es null, se aplica una fuerza para moverlo, 
            // dependiendo del eje donde viene la fuerza
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            // Destruye las balas creadas en cada disparo cada 2 segundos
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

            
        }
    }

    IEnumerator Reload()
    {

        isReloading = true;

        // Se aplica una anumacion para cargar la pistola
        animator.SetBool("Reloading", true);
        txtReloading.gameObject.SetActive(true);

        // Se usa concurrencia para recargar la pistola en el tiempo correcto
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        txtReloading.gameObject.SetActive(false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;

        balas.text = currentAmmo + " / " + maxAmmo;

        isReloading = false;
    }
}
