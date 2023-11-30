using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuWindow : MonoBehaviour {
    private static PauseMenuWindow instance;
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

    public static void ShowPauseMenu() {
        instance.show();
    }

    public static void HidePauseMenu() {
        instance.hide();
    }
}
