using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour {
    private GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null) {
                gameManager.endGame();
            }
        }
    }
}
