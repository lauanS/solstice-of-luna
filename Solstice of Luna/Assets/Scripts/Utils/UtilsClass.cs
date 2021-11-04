using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsClass
{
    static Camera mainCamera = Camera.main;

    public static Vector3 getMouseWorldPosition() {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0f;
        return worldPosition;
    }

    public static Vector3 getRandomDirection() {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1,1f)).normalized;
    }
}
