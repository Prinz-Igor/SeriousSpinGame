using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] WeaponComponent weaponComponent;
	[Export] public float Speed = 300.0f;

	[Signal] public delegate void FireWeaponEventHandler(); 

	public override void _Ready() {
		
	}


	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("inputLeft", "inputRight", "inputUp", "inputDown");
		if (direction != Vector2.Zero)
		{
			velocity = direction * Speed;
		}
		if (direction.X == 0)
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		if (direction.Y == 0)
		{
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		
		

		Velocity = velocity;
		MoveAndSlide();
	}
}
