using System;
public class HealthSystem {
    public event EventHandler OnHealthChanged;

    private int healthMax;
    private int currentHealth;

    public HealthSystem(int health) {
        this.healthMax = health;
        this.currentHealth = health;        
    }

    public int getHealth() {
        return healthMax;
    }

    public int getCurrentHealth() {
        return currentHealth;
    }

    public float getHealthPercent() {
        return (float)currentHealth / healthMax;
    }

    public void heal (int value) {
        if (currentHealth + value > healthMax) {
            currentHealth = healthMax;
            return;
        }
        currentHealth += value;

        emitHealthChanged();
    }

    public void damage (int value) {
        if (currentHealth - value < 0) {
            currentHealth = 0;
            return;
        }
        currentHealth -= value;
        emitHealthChanged();        
    }

    private void emitHealthChanged() {
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

}
