using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;

    public HealthSystem healthSystem;
    public Transform pfHealthBar;
    void Start() {
        anim = GetComponent<Animator>();

        healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(-0.25f, -0.3f), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();

        healthBar.Setup(healthSystem);
    }

    void Update() {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            anim.SetTrigger("Attack");
            // Destroy(collision.gameObject);
        }
    }
}
