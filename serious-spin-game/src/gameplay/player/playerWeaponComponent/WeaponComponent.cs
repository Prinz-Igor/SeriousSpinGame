using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public partial class WeaponComponent : Node2D
{
	[Export] WeaponStats initialWeapon;
	[Export] Sprite2D weaponSprite;
	WeaponStats stats;
	ArrayList projectilepool; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		stats = (WeaponStats)initialWeapon.Duplicate();
		weaponSprite.Texture = stats.weaponSprite; 
		for (int i = 0; i < stats.magazineSize; i++)
		{
			projectilepool.Add("Bang");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void OnPLayerFireWeapon()
	{
		GD.Print(projectilepool[0]);
	}
	

	
}
