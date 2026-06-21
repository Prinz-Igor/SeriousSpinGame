using Godot;
using System;

public partial class Projectile : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] Sprite2D pSprite;
	public ProjectileStats pStats;

	public bool inAir;
	
	public Projectile(ProjectileStats stats)
	{
		pStats = (ProjectileStats)stats.Duplicate();
		pSprite.Texture  = pStats.projectileTexture;
		
	}
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void FireProjectile()
	{
		inAir = true;
	}

	public void OnHit()
	{
		
	}
}
