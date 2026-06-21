using Godot;
using System;

[GlobalClass]
public partial class WeaponStats : Resource
{

    
    [Export] String name = "PlaceholderWeapon";
    [Export] Texture2D weaponSprite;
    [Export] int projectiledamage = 1;
    [Export] int projectileSpeed = 5;
    [Export] int magazineSize = 5;

    [Export] int weaponCooldown = 2;

    [Export] int salvoSize = 1; 


    
}
