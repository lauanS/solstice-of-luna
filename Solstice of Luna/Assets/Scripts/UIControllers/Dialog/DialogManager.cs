using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public Text author;
    public Text content;
    public Image profile;

    private GameManager gameManager;

    private float typingSpeed = 0.05f;
    private bool typing = false;
    private IEnumerator currentTypeCourotine;

    private string[] text;
    private int index;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();

        string[] speak = {"Preciso procurar meu diário!", "Ele deve estar por perto"};

        this.speach("Luna", speak, null);
    }

    public void speach(string author, string[] text, Sprite profile) {
        // this.profile.image = profile;   
        gameManager.pauseActions();

        this.author.text = author;
        this.text = text;

        this.index = 0;

        this.gameObject.SetActive(true);
        currentTypeCourotine = typeSentence();
        StartCoroutine(currentTypeCourotine);
    }

    private IEnumerator typeSentence() {
        typing = true;

        foreach(char letter in text[index].ToCharArray()) {
            content.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        typing = false;
    }

    public void nextSentence() {
        if (typing) {
            StopCoroutine(currentTypeCourotine);
            typing = false;
        }

        if (index < text.Length - 1) {
            index++;
            content.text = "";

            currentTypeCourotine = typeSentence();
            StartCoroutine(currentTypeCourotine);
        } else {
            this.closeDialog();
        }
    }

    public void closeDialog() {
        gameManager.playActions();

        index = 0;
        author.text = "";
        content.text = "";

        this.gameObject.SetActive(false);
    }
}
