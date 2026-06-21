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
	[Export] PackedScene packedProjectile;
	
	public Node entityRoot;
	
	WeaponStats wStats;
	List<Projectile> projectilepool = new List<Projectile>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		wStats = (WeaponStats)initialWeapon.Duplicate();
		weaponSprite.Texture = wStats.weaponSprite; 
		GD.Print("hello");	
		Projectile toInstanceP;
		for (int i = 0; i < wStats.magazineSize; i++)
		{
			toInstanceP = packedProjectile.Instantiate<Projectile>();
			toInstanceP.pStats = wStats.projectileStats;
			toInstanceP.Position = new Vector2(wStats.muzzleOffset, toInstanceP.Position.Y);
			projectilepool.Add(toInstanceP);
			Owner.CallDeferred("add_sibling",projectilepool[i]);

		}
		GD.Print("Projectilepool done");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		LookAt(GetGlobalMousePosition());
	}

	public void OnPLayerFireWeapon()
	{
		//int projectileCount = 0;
		for (int i = 0; i < projectilepool.Count; i++)
		{

			if (!projectilepool[i].inAir)
			{
				Vector2 targetVector = GetGlobalMousePosition().Normalized();
				projectilepool[i].Rotation = this.GlobalRotation;
				projectilepool[i].Position = this.GlobalPosition+targetVector*wStats.muzzleOffset;
				projectilepool[i].targetVector = targetVector;
				projectilepool[i].FireProjectile();
				i=i+projectilepool.Count;
			}
		}
	}
}
