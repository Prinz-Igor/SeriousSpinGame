using Godot;
using System;

[GlobalClass]
public partial class WeaponStats : Resource
{

    
    [Export] public String name = "PlaceholderWeapon";
    [Export] public Texture2D weaponSprite;    
    [Export] public ProjectileStats projectileStats;
    [Export] public int magazineSize = 5;

    [Export] public int weaponCooldown = 2;

    [Export] public int salvoSize = 1; 

    [Export] public int muzzleOffset = 40; 


    
}
