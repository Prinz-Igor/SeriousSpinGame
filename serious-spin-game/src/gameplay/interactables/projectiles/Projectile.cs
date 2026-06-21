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
		pSprite.Visible = false;
		Owner.AddChild(this);
	}
	public override void _Ready()
	{
		ContactMonitor = true;
	}

	public override void _PhysicsProcess(double delta)
	{
		
 		if (inAir)
		{
			//ApplyCentralImpulse(Transform.);
		}
	}

	public void FireProjectile()
	{
		inAir = true;
		pSprite.Visible = true;

	}

	public void OnHit()
	{
		inAir = false;
		Position = new Vector2(0,0);
		pSprite.Visible = false; 
	}
}
