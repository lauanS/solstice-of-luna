using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isWalking;
    public float speed;
    Animator anim;
    

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 2;
    }

    void Update() {
        isWalking = walking();

        if (isWalking)
        {
            anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
            // anim.SetFloat("input_y", Input.GetAxisRaw("Vertical"));
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                rb.velocity = new Vector2(rb.velocity.x, 1 * speed);
                // anim.SetFloat("input_y", Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                rb.velocity = new Vector2(rb.velocity.x, -1 * speed);
                // anim.SetFloat("input_y", Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
                // anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
                // anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
            }
        }
        else {
            rb.velocity = new Vector3(0, 0, 0 );
            // anim.SetFloat("input_x", 0);
            // anim.SetFloat("input_y", 0);
        }
        anim.SetBool("isWalking", isWalking);
    }

    public bool walking()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            return true;
        }
            return false;
    }
}
