using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.Serialization;

public partial class WeaponComponent : Node2D
{
	[Export] WeaponStats initialWeapon;
	[Export] Sprite2D weaponSprite;
	
	WeaponStats wStats;
	List<Projectile> projectilepool;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		wStats = (WeaponStats)initialWeapon.Duplicate();
		weaponSprite.Texture = wStats.weaponSprite; 
		for (int i = 0; i < wStats.magazineSize; i++)
		{
			projectilepool.Add(new Projectile(wStats.projectileStats));
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		LookAt(GetGlobalMousePosition());
	}

	public void OnPLayerFireWeapon()
	{
		int projectileCount = 0;
		for (int i = 0; i < projectilepool.Count; i++)
		{
			if (projectileCount !< wStats.salvoSize) break;

			if (!projectilepool[i].inAir)
			{
				projectilepool[i].targetVector = GetGlobalMousePosition();
				projectilepool[i].FireProjectile();
				i=i+projectilepool.Count;
			}
		}
	}
}
