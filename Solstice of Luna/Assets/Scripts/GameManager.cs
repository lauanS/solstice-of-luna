using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    public Transform pfSlime;
    private GameObject player;

    public bool gamePaused;

    private void Start() {
        initGame();
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            tooglePauseMenu();
        }
    }

    private void initGame() {
        gamePaused = false;
        
        UtilsClass.Setup();

        // Setup dos inimigos
        Enemy.Setup();

        int enemyAmount = 20;
        int defaultEnemyPosX = 0;
        int enemyPosY = -27, enemyPosX = 0;

        // Instanciando inimigos aleatóriamente dentro de um intervalo
        for (int i = 0; i < enemyAmount; i++) {
            enemyPosX = Random.Range(defaultEnemyPosX, defaultEnemyPosX + Random.Range(-12, 12));
            enemyPosY = Random.Range(enemyPosY, enemyPosY - 5);

            Enemy.Create(new Vector3(enemyPosX, enemyPosY, 0), pfSlime);
        }

        // Setup do player
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

    public void tooglePauseMenu() {
        if (gamePaused) {
            playGame();
            PauseMenuWindow.HidePauseMenu();
        } else {
            pauseGame();
            PauseMenuWindow.ShowPauseMenu();
        }
    }

    public void pauseGame() {
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void playGame() {
        gamePaused = false;
        Time.timeScale = 1f;
    }
}
