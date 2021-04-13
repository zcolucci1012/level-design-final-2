using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{

    public float timeToDestruction;
    public int maxCollisions;
    private float timeInstantiated;
    private int collisions = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeInstantiated = Time.time;
        Physics.IgnoreLayerCollision(8, 8);
        Physics.IgnoreLayerCollision(8, 10);
        Physics.IgnoreLayerCollision(9, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeInstantiated >= timeToDestruction || collisions >= maxCollisions) {
            ProjectileDestroyer();
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag != "Projectile" && other.gameObject.tag != "EnemyProjectile")
        {
            collisions++;
        } 
    }

    void ProjectileDestroyer() {
        Destroy(gameObject);
    }
}
