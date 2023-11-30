using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Responsável pelo comportamento do item dropado */
public class Drop : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}

