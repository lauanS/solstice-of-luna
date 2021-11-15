using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Transform pfSlime;
    private GameObject player;

    void Start() {
        initGame();
    }

    private void initGame() {
        UtilsClass.Setup();
        Enemy.Setup();

        Enemy slime = Enemy.Create(new Vector3(-20, -26, 0), pfSlime);
        Enemy slime2 = Enemy.Create(new Vector3(-15.5f, -26.9f, 0), pfSlime);
        Enemy slime3 = Enemy.Create(new Vector3(-11.5f, -26.9f, 0), pfSlime);
        Enemy slime4 = Enemy.Create(new Vector3(-9.5f, -26.9f, 0), pfSlime);
        Enemy slime5 = Enemy.Create(new Vector3(-7.6f, -26.9f, 0), pfSlime);
        Enemy slime6 = Enemy.Create(new Vector3(-2.5f, -26.9f, 0), pfSlime);
        Enemy slime7 = Enemy.Create(new Vector3(5f, -26.9f, 0), pfSlime);
        Enemy slime8 = Enemy.Create(new Vector3(9f, -26.9f, 0), pfSlime);
        Enemy slime9 = Enemy.Create(new Vector3(15f, -26.9f, 0), pfSlime);

        player = GameObject.FindGameObjectWithTag("Player");
        Player playerScript = player.GetComponent<Player>();

        playerScript.OnPlayerDie += callOnPlayerDie;
    }

    public void gameOver() {
        pauseGame();
        GameOverWindow.ShowGameOver();
    }

    public void reloadGame() {
        playGame();
        GameOverWindow.HideGameOver();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void callOnPlayerDie(object sender, EventArgs e) {
        gameOver();        
    }

    public void pauseGame() {
        Time.timeScale = 0f;
    }

    public void playGame() {
        Time.timeScale = 1f;
    }
}
