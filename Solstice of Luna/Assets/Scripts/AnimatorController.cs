using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {
    public bool isWalking;
    public float speed;
    private Animator anim;
    private Player player;
    

    void Start() {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();

        
        speed = 3;
    }

    private void playMovementAnim() {
        if (isWalking) {
            anim.SetFloat("input_x", Input.GetAxisRaw("Horizontal"));
        }

        anim.SetBool("isWalking", isWalking);
    }

    private void playAttackAnim() {
        
    }
}
