using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 50;
    public int currentHealth;
    public GameObject projectilePrefab;
    private GameObject player;
    public float projectileSpeed = 50f;
    public float fireRate = 2;
    private float fireTime = 0;
    private Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        player = GameObject.Find("Player");
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
        player.GetComponent<PlayerHealth>().TakeDamage(-10);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        int damping = 4;
        var lookPos = player.transform.position - this.transform.position;
        var abovePlayerHead = lookPos;
        abovePlayerHead.y += 1;
        this.playerDirection = abovePlayerHead / abovePlayerHead.magnitude;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        fireTime += Time.deltaTime;
        if (fireTime > fireRate)
        {
            Shoot();
            fireTime = 0;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab,
                transform.position + transform.forward, transform.rotation) as GameObject;

        if (!projectile.GetComponent<Rigidbody>())
        {
            projectile.AddComponent<Rigidbody>();
        }

        var rb = projectile.GetComponent<Rigidbody>();

        rb.AddForce(playerDirection * projectileSpeed, ForceMode.VelocityChange);

        projectile.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileParent").transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(20);
        }
    }
}
