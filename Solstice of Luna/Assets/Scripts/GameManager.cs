using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HealthSystem healthSystem;
    public Transform pfHealthBar;
    void Start() {
        healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 0), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();

        healthBar.Setup(healthSystem);

        Debug.Log("Current life: " + healthSystem.getCurrentHealth());

        healthSystem.damage(15);

        Debug.Log("Current life: " + healthSystem.getCurrentHealth());

        healthSystem.heal(10);

        Debug.Log("Current life: " + healthSystem.getCurrentHealth());

        healthSystem.damage(40);
        Debug.Log("Current life: " + healthSystem.getCurrentHealth());
    }

    void Update() {
        
    }
}
