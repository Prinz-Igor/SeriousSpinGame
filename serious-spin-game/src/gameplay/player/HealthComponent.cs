using Godot;
using System;
using System.ComponentModel;

public partial class HealthComponent : Node
{
    [Export] public float maxHealth = 20;
    [Signal] public delegate void DeathEventHandler();
    
    public bool HasHealthRemaining => !Mathf.IsEqualApprox(currentHealth,0f);
    public float CurrentHealthPercent => maxHealth > 0 ? currentHealth / maxHealth : 0f; 

    public float currentHealth
    {
        get => currentHealth;
        private set
        {
            //currentHealth = Mathf.Clamp(value,0,maxHealth);
            currentHealth=value;
            CheckDeath();
        }

    }

    public override void _Ready()
    {
        //InitializeHealth();
    }

    private void InitializeHealth()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
    }

    public void Heal(float heal)
    {
        Damage(-heal);
    }

    public void CheckDeath()
    {
        if (currentHealth<=0)
        {
            EmitSignal(SignalName.Death);
        }
    }

}
