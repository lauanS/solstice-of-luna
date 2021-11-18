using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator anim;

    public HealthSystem healthSystem;
    public Transform pfHealthBar;
    public Transform defaultEnemy;
    private static List<Enemy> enemyList;

    /* Events */
    public event EventHandler OnTakeDamage;

    void Start() {
        healthSystem = new HealthSystem(100);
        healthSystem.OnHealthOver += removeEnemy;
        healthSystem.OnTakeDamage += emitTakeDamage;

        anim = GetComponent<Animator>();

        Transform healthBarTransform = Instantiate(pfHealthBar, gameObject.transform.position + new Vector3(0.4f, -0.4f), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();

        healthBar.transform.SetParent(gameObject.transform);

        healthBar.Setup(healthSystem);
    }

    public static void Setup() {
        enemyList = new List<Enemy>();
    }

    public static Enemy Create(Vector3 position, Transform pfEnemy) {
        Transform enemyTransform = Instantiate(pfEnemy, position, Quaternion.identity);

        Enemy enemy = enemyTransform.GetComponent<Enemy>();
        
        if (enemyList == null) enemyList = new List<Enemy>();
        enemyList.Add(enemy);

        return enemy;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            anim.SetTrigger("Attack");
        }
    }

    public void takeDamage(int damage) {
        healthSystem.damage(damage);
    }

    private void removeEnemy(object sender, EventArgs e) {
        enemyList.Remove(this);
        Destroy(gameObject);
    }

    private void emitTakeDamage(object sender, EventArgs e) {
        if (OnTakeDamage != null) OnTakeDamage(this, e);
    }

    public static Enemy GetClosestEnemy(Vector3 position, float range) {
        if (enemyList == null) return null;

        Enemy closestEnemy = null;

        for (int i = 0; i < enemyList.Count; i++) {
            Enemy testEnemy = enemyList[i];

            if (Vector3.Distance(position, testEnemy.transform.position) > range) {
                continue;
            }

            if (closestEnemy == null) {
                closestEnemy = testEnemy;
            } else {
                if (Vector3.Distance(position, testEnemy.transform.position) < Vector3.Distance(position, closestEnemy.transform.position)) {
                    closestEnemy = testEnemy;
                }
            }
        }

        return closestEnemy;
    }
}
