using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float projectileSpeed = 400f;
    public GameObject projectilePrefab;
    public AudioClip shootSFX;
    private bool canShoot = true;

    //private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        //levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot) {
            GameObject projectile = Instantiate(projectilePrefab, 
                transform.position + transform.forward, transform.rotation) as GameObject;

            if(!projectile.GetComponent<Rigidbody>()) {
                projectile.AddComponent<Rigidbody>();
            } 

            var rb = projectile.GetComponent<Rigidbody>();
            
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);

            projectile.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileParent").transform);

            //AudioSource.PlayClipAtPoint(shootSFX,
            //GameObject.FindGameObjectWithTag("MainCamera").transform.position, 0.2f);
        }
    }

    public void SetShooting(bool shoot) {
        canShoot = shoot;
    }
}
