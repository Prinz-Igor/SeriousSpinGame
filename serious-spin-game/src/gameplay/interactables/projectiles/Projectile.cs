using Godot;
using System;
using System.Threading.Tasks;

public partial class Projectile : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] Sprite2D pSprite;
	[Export] int despawnTime = 5;
	public ProjectileStats pStats;
	public bool inAir;
	public Vector2 targetVector;
	public Vector2 origin; 
	
	

	public override void _Ready()
	{
		Visible = false; 
		origin = Position;
	}

	public override void _PhysicsProcess(double delta)
	{
 		if (inAir)
		{
			Vector2 velocity = Velocity;
			velocity = targetVector * pStats.speed;
			Velocity = velocity;
		}
		MoveAndSlide();
	}

	public void FireProjectile()
	{
		inAir = true;
		Visible = true;
		despawn();
	}

	public async Task despawn()
	{
		await ToSignal(GetTree().CreateTimer(despawnTime), SceneTreeTimer.SignalName.Timeout);
		if (inAir)	ResetBullet();
	}

	public void OnHit(Node2D target)
	{
		//Target hit logic here
		ResetBullet();
		
	}

	public void ResetBullet()
	{
		inAir = false;
		Velocity = new Vector2(0,0);
		Position = origin;
		Visible = false;
	}
	
}
