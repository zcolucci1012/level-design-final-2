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
    public float walkSpeed = 3f;
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

    protected virtual void EnemyDies()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(-10);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        int damping = 4;
        var lookPos = player.transform.position - (this.transform.position + this.transform.up * 4);
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

        RaycastHit hit;

        var mask = ~LayerMask.GetMask("Player", "Enemy");
        var adjusted = (abovePlayerHead - new Vector3(0, 1.5f, 0));
        var direction = adjusted / adjusted.magnitude;
        if (!Physics.Raycast((this.transform.position + this.transform.up * 4),
            direction, out hit, abovePlayerHead.magnitude, mask))
        {
            Move();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab,
                transform.position + transform.forward + transform.up * 4, transform.rotation) as GameObject;

        if (!projectile.GetComponent<Rigidbody>())
        {
            projectile.AddComponent<Rigidbody>();
        }

        var rb = projectile.GetComponent<Rigidbody>();

        rb.AddForce(playerDirection * projectileSpeed, ForceMode.VelocityChange);

        projectile.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileParent").transform);
    }

    protected virtual void Move()
    {
        var direction = new Vector3(this.playerDirection.x,
            0,
            this.playerDirection.z);
        transform.position += this.playerDirection * Time.deltaTime * walkSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(20);
        }
    }
}
