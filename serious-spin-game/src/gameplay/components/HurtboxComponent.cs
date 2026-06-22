using Godot;
using System;

public partial class HurtboxComponent : Area2D
{
	[Export] HealthComponent healthComponent;
	[Export] String HurtBoxGroup = "Player";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Monitoring=true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void DealDamage(float damage)
	{
		healthComponent.Damage(damage);
	}

	public void OnBodyEntered(Node2D body)
	{
		int damage = 0;
		if (body is Projectile projectile)
		{
			damage = projectile.pStats.damage;
		}
		DealDamage(damage);
	}
}
