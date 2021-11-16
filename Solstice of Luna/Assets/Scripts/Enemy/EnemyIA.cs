using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {
    private Vector3 startingPosition;
    private Vector3 roamPosition;

    private float speed = 0.025f;
    private GameObject player;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        startingPosition = transform.position;
        roamPosition = getRoamingPosition();
    }

    private void Update() {
        if (Vector3.Distance(transform.position, roamPosition) < 0.1f) {
            roamPosition = getRoamingPosition();
        }

        findTarget();        
    }

    private void FixedUpdate() {
        moveToTarget();
    }

    private void moveToTarget() {
        Vector3 dir = (roamPosition - transform.position).normalized;
        rb.MovePosition(transform.position + dir * speed);
    }

    private Vector3 getRoamingPosition() {
        float randomDistance = Random.Range(2f, 1f);
        return startingPosition + UtilsClass.getRandomDirection() * randomDistance;
    }

    private void findTarget() {
        float targetRange = 1.5f;
        if (Vector3.Distance(transform.position, player.transform.position) < targetRange) {
            speed = 0.04f;
            roamPosition = player.transform.position;
        } else {
            speed = 0.025f;
        }
    }
}