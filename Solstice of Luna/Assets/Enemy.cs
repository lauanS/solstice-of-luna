using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            anim.SetTrigger("Attack");
            Destroy(collision.gameObject);
        }
    }
}
