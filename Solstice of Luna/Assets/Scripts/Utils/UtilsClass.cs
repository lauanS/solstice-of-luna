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
}
