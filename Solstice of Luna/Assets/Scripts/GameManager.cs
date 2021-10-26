using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    void Start() {
        Enemy slime = Enemy.Create(new Vector3(0, 0, 0));
        Enemy slime2 = Enemy.Create(new Vector3(1, 1, 0));
        Enemy slime3 = Enemy.Create(new Vector3(-1.5f, 1.5f, 0));
    }

    void Update() {
        
    }
}
