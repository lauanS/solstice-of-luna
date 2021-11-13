using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {
    private HealthSystem healthSystem;
    public Transform pfHealthBar;

    /* Events */
    public event EventHandler OnPlayerDie;

    void Start() {
        // Inicializa o healthSystem
        healthSystem = new HealthSystem(100);

        // Inscreve-se no evento para saber quando o Player morre
        healthSystem.OnHealthOver += emitPlayerDie;

        // Setup da barra de vida
        Vector3 healthBarPosition = gameObject.transform.position + new Vector3(0.4f, 0.1f, 0);

        Transform healthBarTransform = Instantiate(pfHealthBar, healthBarPosition, Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();

        healthBar.transform.SetParent(gameObject.transform);
        
        healthBar.Setup(healthSystem);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            takeDamage(25);
        }
    }

    public void takeDamage(int damage) {
        healthSystem.damage(damage);
    }

    private void emitPlayerDie(object sender, EventArgs e) {
        gameObject.SetActive(false);
        if (OnPlayerDie != null) OnPlayerDie(this, e);
    }
}
