using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour {
    private GameManager gameManager;
    public DialogSpeaker dialogSpeaker;

    private void Start() {
        dialogSpeaker = GetComponent<DialogSpeaker>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            dialogSpeaker.interact();
        }
    }
}
