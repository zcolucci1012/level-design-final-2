using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 50;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            EnemyDies();
        }
    }

    void EnemyDies()
    {
        GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(-10);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {

    }
}
