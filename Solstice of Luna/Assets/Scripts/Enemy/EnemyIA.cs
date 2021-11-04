using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    float speed = 1;
    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        startingPosition = transform.position;
        roamPosition = getRoamingPosition();
    }

    private void Update() {
        float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, roamPosition, step);

        if (Vector3.Distance(transform.position, roamPosition) < 0.002f) {
            roamPosition = getRoamingPosition();
        }

        findTarget ();        
    }

    private Vector3 getRoamingPosition () {
        float randomDistance = Random.Range(3f, 2f);
        return startingPosition + UtilsClass.getRandomDirection() * randomDistance;
    }

    private void findTarget () {
        float targetRange = 1f;
        if (Vector3.Distance(transform.position, player.transform.position) < targetRange) {
            roamPosition = player.transform.position;
        }
    }
}