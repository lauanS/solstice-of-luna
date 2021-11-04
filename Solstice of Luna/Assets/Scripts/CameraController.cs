using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Header("Link o objeto")]
    public GameObject target;
    private Vector3 positionTarget;


    [Header("Dados da Camera")]
    public float speed;

    void Start() {
        speed = 2;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (target) {
            positionTarget = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

            Vector3 tempPosition = Vector3.Lerp(transform.position, positionTarget, speed);

            transform.position = tempPosition;
        }        
    }
}
