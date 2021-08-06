using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    public GameObject stand;
    public GameObject crouch;

    Rigidbody2D rb;

    bool isJumping;

    public GameManager gameManager;

    AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;

        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("up") || Input.GetKey("space")) && isJumping == false)
        {
            rb.velocity = new Vector3(0, 20, 0);
            isJumping = true;

            jumpSound.Play();
        }

        if (Input.GetKey("down") && isJumping == false)
        {
            crouch.SetActive(true);
            stand.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstacle")
        {
            gameManager.GameOver();
        }
    }
}
