using Timer;
using Godot;

namespace Weapons.Weapon
{
    public abstract partial class WeaponBase : Node3D
    {
        //This part defenetly needs refactoring
        [Export] private float fireRate {get;set;}
        [Export] protected float damage{get;set;}
        [Export] protected float speed{get;set;}
        [Export] protected float lifeTime{get;set;}

        [Export] protected Vector3 shotPoint;

        protected RepeatableTimer _timer;

        public override void _Ready()
        {
           _timer = new RepeatableTimer(fireRate);
        }
        public abstract void Shoot();
    }
}