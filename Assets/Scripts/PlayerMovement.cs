﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;
    public float speed = 10f;
    public float gravity = 9.81f;
    Vector3 moveDirection;
    public float jumpHeight = 10f;
    public float airControl = 10f;
    public AudioClip jumpSFX;

    //private LevelManager levelManager;
    public PlayerHealth playerHealth;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        //levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            var input = transform.right * moveHorizontal + transform.forward * moveVertical;
            input *= speed;

            if (controller.isGrounded)
            {
                moveDirection = input;
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = Mathf.Sqrt(2 * gravity * jumpHeight);
                     //AudioSource.PlayClipAtPoint(jumpSFX, GameObject.FindGameObjectWithTag("MainCamera").transform.position, 0.5f);
                }
            }
            else
            {
                // the object is in the air
                input.y = moveDirection.y;
                moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        /*if (!playerHealth.isPlayerDead)
        {
            
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            playerHealth.TakeDamage(10);
        }
    }
}
