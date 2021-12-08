using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpeaker : MonoBehaviour {
    public string author;
    public string text;
    public Sprite profile;

    public DialogManager dialogManager;

    void Start() {
        this.dialogManager = FindObjectOfType<DialogManager>();
    }

    public void interact() {
        Debug.Log("interect");
        if (this.dialogManager != null) {
            this.dialogManager.speach(author, text, profile);
        }
    }
}
