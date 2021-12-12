using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/* Responsável por fazer algum item dropar */
public class ItemDrop : MonoBehaviour {
    public Transform pfLifeGem;
    private Enemy enemy;

    private void Start() {
        enemy = this.gameObject.GetComponent<Enemy>();
        enemy.OnEnemyDie += dropItem;
    }

    public void dropItem (object sender, EventArgs e) {
        if(Random.Range(0, 100) > 50) {
            Vector3 lifeGemPosition = transform.position + new Vector3(0, -0.3f, 0);
            Transform lifeGemTransform = Instantiate(pfLifeGem, lifeGemPosition, Quaternion.identity);
        }
    }
}
