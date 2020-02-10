using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 100f;

    public bool esEnemigoMuerto = false;

    public float actualHealth;

    public Image healthBar;


    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / 100f;

        if (health <= 0f)
        {
            Die();
            EsEnemigoMuerto();
        }
    }


    public bool EsEnemigoMuerto()
    {
        esEnemigoMuerto = true;

        return esEnemigoMuerto;
    }


    private void Die()
    {
        Destroy(gameObject);
    }
}
