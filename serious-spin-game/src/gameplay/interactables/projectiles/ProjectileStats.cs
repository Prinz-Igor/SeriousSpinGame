using Godot;
using System;
[GlobalClass]
public partial class ProjectileStats : Resource
{
    [Export] public Texture2D projectileTexture;
    [Export] public int damage = 1;
    [Export] public int speed = 5;
    

}
