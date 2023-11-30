using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {
    public bool isWalking;
    public bool isAttacking;

    /* Components */
    private Animator anim;
    private Color regularColor;
    private SpriteRenderer rend;
    public Player player;
    public Enemy enemy;

    void Start() {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();

        rend = GetComponent<SpriteRenderer>();

        regularColor = rend.material.color;

        if (player != null) {
            player.OnAttack += playAttack;
            player.OnTakeDamage += playTakeDamage;
        }

        if (enemy != null) {
            enemy.OnTakeDamage += playTakeDamage;
        }
    }

    private void playMovementAnim() {
        if (isWalking) {
            anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
        }

        anim.SetBool("isWalking", isWalking);
    }

    private void playAttack(object sender, EventArgs e) {
        StartCoroutine(playAttackAnim());
    }

    private void playTakeDamage(object sender, EventArgs e) {
        StartCoroutine(playTakeDamageAnim());
    }

    private IEnumerator playAttackAnim() {
        anim.SetBool("isAttacking", true);
        this.isAttacking = true;

        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isAttacking", false);
        this.isAttacking = false;
    }

    private IEnumerator playTakeDamageAnim() {
        Color flashColor = regularColor;
        flashColor.a = 0.5f;

        int flashCount = 0;
        float flashDuration = 0.3f;
        int numberOfFlashs = 3;

        while (flashCount < numberOfFlashs) {
            rend.material.color = flashColor;
            yield return new WaitForSeconds(flashDuration);

            rend.material.color = regularColor;
            yield return new WaitForSeconds(flashDuration);

            flashCount++;            
        }
    }
}
