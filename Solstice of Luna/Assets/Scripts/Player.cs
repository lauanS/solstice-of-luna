using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private HealthSystem healthSystem;
    public Transform pfHealthBar;

    void Start() {
        healthSystem = new HealthSystem(100);

        Vector3 healthBarPosition = gameObject.transform.position + new Vector3(0.4f, 0.1f, 0);

        Transform healthBarTransform = Instantiate(pfHealthBar, healthBarPosition, Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();

        healthBar.transform.SetParent(gameObject.transform);
        
        healthBar.Setup(healthSystem);        
    }

    public void takeDamage(int damage) {
        healthSystem.damage(damage);
        if (healthSystem.getCurrentHealth() == 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            takeDamage(25);
        }
    }
}
