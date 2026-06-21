using Godot;
using System;
using System.Runtime.Serialization;

public partial class WeaponComponent : Node2D
{
	[Export] WeaponStats initialWeapon;
	[Export] Sprite2D weaponSprite;
	WeaponStats stats;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		stats = (WeaponStats)initialWeapon.Duplicate();
		weaponSprite.Texture = stats.weaponSprite; 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void OnPLayerFireWeapon()
	{
		
	}
}
