using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {
    [Header("Interações")]
    public string enemyTag;
    public string baseCharacterClass;

    private float thrust = 2;
    private Rigidbody2D rb;
    public Enemy baseCharacter;
    private EnemyIA controller;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        baseCharacter = GetComponent(baseCharacterClass) as Enemy;
        controller = GetComponent("EnemyIA") as EnemyIA;

        baseCharacter.OnTakeDamage += knockBack;
        baseCharacter.OnAttack += knockBack;
    }

    public void knockBack(object sender, EventArgs e) {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = (transform.position - player.transform.position).normalized;

        controller.loseControl(0.8f);

        StartCoroutine(knockBackCoroutine(direction));
    }

    private IEnumerator knockBackCoroutine(Vector3 direction) {
        Vector3 force = direction * thrust;

        rb.velocity = force;
        yield return new WaitForSeconds(0.16f);
        rb.velocity = new Vector3();
    }
}
