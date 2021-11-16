using System;
public class HealthSystem {
    public event EventHandler OnHealthChanged;
    public event EventHandler OnHealthOver;
    public event EventHandler OnTakeDamage;

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
        emitTakeDamage();

        if (currentHealth - value <= 0) {
            currentHealth = 0;
            emitHealthOver();
            return;
        }

        currentHealth -= value;
        emitHealthChanged();        
    }

    private void emitHealthChanged() {
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    private void emitHealthOver() {
        if (OnHealthOver != null) OnHealthOver(this, EventArgs.Empty);
    }

    private void emitTakeDamage() {
        if (OnTakeDamage != null) OnTakeDamage(this, EventArgs.Empty);
    }

}
