using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWindow : MonoBehaviour {
    private static GameOverWindow instance;

    private void Awake() {
        instance = this;
        hide();
    }

    public void show() {
        gameObject.SetActive(true);
    }

    private void hide() {
        gameObject.SetActive(false);
    }

    public static void ShowGameOver() {
        instance.show();
    }

    public static void HideGameOver() {
        instance.hide();
    }
}
