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
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeInstantiated >= timeToDestruction || collisions >= maxCollisions) {
            ProjectileDestroyer();
        }
    }

    void OnCollisionEnter(Collision other) {
        collisions++;
    }

    void ProjectileDestroyer() {
        Destroy(gameObject);
    }
}
