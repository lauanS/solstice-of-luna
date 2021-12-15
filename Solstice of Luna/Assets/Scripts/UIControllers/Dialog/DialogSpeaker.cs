using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpeaker : MonoBehaviour {
    public string author;
    public string[] text = {"Luna, preciso da sua ajuda", "Estarei de esperando na Ilha Momish", "- S"};
    public Sprite profile;

    private DialogManager dialogManager;

    void Start() {
        this.dialogManager = FindObjectOfType<DialogManager>();
    }

    public void interact() {
        if (this.dialogManager != null) {
            this.dialogManager.speach(author, text, profile);
        }
    }
}
