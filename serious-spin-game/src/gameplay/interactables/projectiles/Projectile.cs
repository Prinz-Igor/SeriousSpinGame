using Godot;
using System;

public partial class Projectile : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] Sprite2D pSprite;
	public ProjectileStats pStats;
	public bool inAir;
	public Vector2 targetVector;
	
	public Projectile(ProjectileStats stats)
	{
		pStats = (ProjectileStats)stats.Duplicate();
		pSprite.Texture  = pStats.projectileTexture;
		pSprite.Visible = false;
		Owner.AddChild(this);
	}
	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		
 		if (inAir)
		{
			Vector2 velocity = Velocity;
			velocity = targetVector * pStats.speed;
			Velocity = velocity;
		}
		
	}

	public void FireProjectile()
	{
		inAir = true;
		pSprite.Visible = true;

	}

	public void OnHit(Node2D target)
	{
		inAir = false;
		Velocity = new Vector2(0,0);
		Position = new Vector2(0,0);
		pSprite.Visible = false;
	}
}
