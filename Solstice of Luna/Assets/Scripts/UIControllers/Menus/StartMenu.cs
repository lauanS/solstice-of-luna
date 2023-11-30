using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public void onPressStart() {
        SceneManager.LoadScene("Main");
    }

    public void onPressQuit() {
        Application.Quit();
    }
}
