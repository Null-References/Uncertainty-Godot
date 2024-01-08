using Godot;
using Shooting;

namespace Weapons.Weapon
{
    public partial class Blaster : WeaponBase
    {
        private int _ownerID;
        [Export] Node3D target;
        public override void _Ready()
        {
            base._Ready();
        }
        public override void _Process(double delta)
        {
            LookAt(target.Position,Vector3.Up);
            _timer.Tick((float)delta);
            Shoot();
        }
        public override void Shoot()
        {
            if (_timer.IsReady())
            {
                var projectile = BulletPool.Instance.Get();
                projectile.SetProperties(speed,damage,lifeTime,Position,Quaternion);
            }
        }
    }
}