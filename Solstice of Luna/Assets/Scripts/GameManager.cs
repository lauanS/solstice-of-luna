using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Transform pfSlime;
    void Start() {
        Enemy slime = Enemy.Create(new Vector3(0, 0, 0), pfSlime);
        Enemy slime2 = Enemy.Create(new Vector3(1, 1, 0), pfSlime);
        Enemy slime3 = Enemy.Create(new Vector3(-1.5f, 1.5f, 0), pfSlime);
    }

    public void gameOver() {
        pauseGame();
    }

    public void pauseGame() {
        Time.timeScale = 0f;
    }

    public void playGame() {
        Time.timeScale = 1f;
    }
}
