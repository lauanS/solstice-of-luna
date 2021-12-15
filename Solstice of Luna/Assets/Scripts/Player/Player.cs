using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {
    private HealthSystem healthSystem;
    private PlayerController controller;
    public Transform pfHealthBar;

    public HealthBar healthBar;

    /* Events */
    public event EventHandler OnPlayerDie;
    public event EventHandler OnTakeDamage;
    public event EventHandler OnAttack;

    void Start() {
        // Inicializa o healthSystem
        healthSystem = new HealthSystem(100);

        // Inscreve-se nos eventos do healthSystem
        healthSystem.OnHealthOver += emitPlayerDie;
        healthSystem.OnTakeDamage += emitTakeDamage;

        // Controler do personagem
        controller = GetComponent<PlayerController>();
        controller.OnAttack += emitAttack;

        // Setup da barra de vida
        GameObject staticHealthBar = GameObject.FindGameObjectWithTag("HealthBar");

        if (staticHealthBar != null) {
            // Setup da HealthBar estática na tela
            healthBar = staticHealthBar.GetComponent<HealthBar>();
        } else {
            // Setup da HealthBar em cima do personagem
            Vector3 healthBarPosition = gameObject.transform.position + new Vector3(0.4f, 0.1f, 0);

            Transform healthBarTransform = Instantiate(pfHealthBar, healthBarPosition, Quaternion.identity);
            healthBar = healthBarTransform.GetComponent<HealthBar>();

            healthBar.transform.SetParent(gameObject.transform);
        }
        
        healthBar.Setup(healthSystem);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            takeDamage(20);
        }
        if (collision.gameObject.tag == "LifeRegen") {
            heal(10);
        }
    }

    public void takeDamage(int damage) {
        healthSystem.damage(damage);
    }

    public void heal(int value) {
        healthSystem.heal(value);
    }

    private void emitPlayerDie(object sender, EventArgs e) {
        gameObject.SetActive(false);
        if (OnPlayerDie != null) OnPlayerDie(this, e);
    }

    private void emitTakeDamage(object sender, EventArgs e) {
        if (OnTakeDamage != null) OnTakeDamage(this, e);
    }

    private void emitAttack(object sender, EventArgs e) {
        if (OnAttack != null) OnAttack(this, EventArgs.Empty);
    }    
}