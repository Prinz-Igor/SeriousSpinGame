using Godot;
using System;

[GlobalClass]
public partial class WeaponStats : Resource
{
    [Export] String name = "PlaceholderWeapon";
    [Export] Texture2D weaponSprite;
    [Export] int projectiledamage = 1;
    [Export] int projectileSpeed = 5;
    
}
