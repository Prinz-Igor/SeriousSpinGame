using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.Serialization;

public partial class WeaponComponent : Node2D
{
	//Export Nodes that are set in Inspector for essential game function
	[Export] WeaponStats initialWeapon;
	[Export] Sprite2D weaponSprite;
	[Export] PackedScene packedProjectile;

	//Keeps track of the Node above the player so that the Projectiles arent parented to the player	
	public Node entityRoot;
	
	//Bullets currently in Magazine
	public int curMag = 0; 
	
	//Ressource containing all stats about the Weapon
	WeaponStats wStats;

	//Projectilepool, so that all Projectiles of any given magazine are always loaded and dont cause runtime lag
	List<Projectile> projectilepool = new List<Projectile>();

	//Variables to measure how much the player spins. 
	public float previousAngle = 0; 
	public float mouseAngle =0;
	public float mouseAngleDif=0;

	/*	Called when the node enters the scene tree for the first time.
		Sets up Projectilepool, EntityRoot and loads the Weapon- and Projectilestats. 
	*/
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
        HandleMouseInput();

        if (Input.IsActionJustPressed("weaponFire") && curMag > 0)
        {
            handleFireInput();
        }
    }

    private void HandleMouseInput()
    {
        LookAt(GetGlobalMousePosition());
		
		previousAngle = mouseAngle;
        mouseAngle = Mathf.RadToDeg(Rotation);
		mouseAngleDif += mouseAngle - previousAngle;
		if (Mathf.Abs(mouseAngleDif)>=360)
		{
			if (curMag < wStats.magazineSize) curMag++;
			if (mouseAngleDif > 0){
				mouseAngleDif -= 360;
			}
			else mouseAngleDif+= 360;
			
		}
		//GD.Print("MouseAngle:"+ mouseAngle+"\n previousangle"+previousAngle+"\n MouseangleDif:" + mouseAngleDif + "\n Magazine:" + curMag);
    }


    private void handleFireInput()
    {
            int salvo = 0;
            while (!Input.IsActionJustReleased("weaponFire") && salvo < wStats.salvoSize)
            {
                OnPLayerFireWeapon();
                salvo++;
				curMag--;
				mouseAngleDif=0;
		    }
    }

    public void OnPLayerFireWeapon()
	{
		for (int i = 0; i < projectilepool.Count; i++)
		{
			if (!projectilepool[i].inAir)
			{
				Vector2 targetVector = (GetGlobalMousePosition() - this.GlobalPosition).Normalized();
				projectilepool[i].Rotation = this.GlobalRotation;
				projectilepool[i].Position = this.GlobalPosition;
				projectilepool[i].targetVector = targetVector; 
				projectilepool[i].FireProjectile();
				i=i+projectilepool.Count;
				GD.Print("Mouse Position"+GetGlobalMousePosition()+"\nTargetVector:"+targetVector);
				
			}
		}
	}
}
