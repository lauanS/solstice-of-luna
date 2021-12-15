using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour {
    private GameManager gameManager;
    public Sprite profile;
    public DialogSpeaker dialogSpeaker;

    private void Start() {
        dialogSpeaker = GetComponent<DialogSpeaker>();
        dialogSpeaker.profile = profile;
        dialogSpeaker.text = new string[] {
            "Luna, se você está lendo isso agora, significa que não consegui escapar",
            "O Rei descobriu tudo e vai me prender no castelo",
            "Vou tentar fazer o possível para conseguir fugir, mas ele é muito poderoso.",
            "Preciso ir agora, estão me procurando, espero que esta carta chegue até você.",
            "Sempre sua, YongSun"
        };
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            dialogSpeaker.interact();
        }
    }
}
