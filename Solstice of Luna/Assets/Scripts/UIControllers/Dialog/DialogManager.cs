using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public Text author;
    public Text content;
    public Image profile;

    private float typingSpeed = 0.05f;
    private string text;

    private void Start() {
        this.speach("Luna", "Preciso descer!", null);
    }

    public void speach(string author, string text, Sprite profile) {
        // this.profile.image = profile;
        Debug.Log("speach");
        this.author.text = author;
        this.text = text;

        this.gameObject.SetActive(true);
        StartCoroutine(typeSentence());
    }

    private IEnumerator typeSentence() {
        foreach(char letter in text.ToCharArray()) {
            content.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void closeDialog() {
        this.gameObject.SetActive(false);
    }
}
