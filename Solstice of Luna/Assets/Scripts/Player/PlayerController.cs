using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private enum State {
        Normal,
        Attacking
    }

    public Rigidbody2D rb;
    public bool isWalking;
    public float speed;
    Animator anim;
    
    private State state;

    public event EventHandler OnAttack;
    

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 3;

        state = State.Normal;
    }

    void Update() {
        switch (state) {
        case State.Normal:
            movement();
            attack();
            break;
        case State.Attacking:
            break;
        }
        
    }

    public bool walking() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            return true;
        }
            return false;
    }

    private void movement() {
        isWalking = walking();

        float moveX = 0;
        float moveY = 0;

        if (isWalking) {
            anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
            // anim.SetFloat("input_y", Input.GetAxisRaw("Vertical"));
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                moveY = +1f;
                // anim.SetFloat("input_y", Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                moveY = -1f;
                // anim.SetFloat("input_y", Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                moveX = -1f;
                // anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                moveX = +1f;
                // anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
            }
            rb.velocity = (new Vector2(moveX, moveY).normalized) * speed;
        }
        else {
            rb.velocity = new Vector3(0, 0, 0);
            // anim.SetFloat("input_x", 0);
            // anim.SetFloat("input_y", 0);
        }

        anim.SetBool("isWalking", isWalking);
    }

    private void attack() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = UtilsClass.getMouseWorldPosition();
            Vector3 mouseDirection = (mousePosition - transform.position).normalized;

            float attackOffset = 0.2f;

            Vector3 attackPosition = transform.position + mouseDirection * attackOffset;

            float attackRange = 0.8f;

            Enemy enemy = Enemy.GetClosestEnemy(attackPosition, attackRange);

            if (enemy != null) enemy.takeDamage(20);

            // Para o personagem
            rb.velocity = new Vector3(0, 0, 0);
            emitAttack();
        }
    }

    private void emitAttack() {
        if (OnAttack != null) OnAttack(this, EventArgs.Empty);
    }
}
