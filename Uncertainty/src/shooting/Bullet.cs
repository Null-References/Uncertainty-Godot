using Godot;
using HealthSystem;
using Timer;
using Utils;
namespace Shooting
{
    public partial class Bullet : Area3D, IPoolObject
    {
        float _speed;
        float _damage;
        RepeatableTimer _timer = new RepeatableTimer(1);
        public void Disable()
        {
            AreaEntered -= OnAreaEntered;
        }

        public void Enable()
        {
            AreaEntered += OnAreaEntered;
        }

        private void OnAreaEntered(Area3D other)
        {
            IDamagable damagable = other as IDamagable;
            damagable?.TakeDamage(_damage);
        }
        public void SetProperties(float speed, float damage, float lifeTime, Vector3 posision, Quaternion rotation)
        {
            _speed = speed;
            _damage = damage;
            _timer.ResetTimer(lifeTime);
            Position = posision;
            Quaternion = rotation;
        }
        public override void _PhysicsProcess(double delta)
        {
            Position += -Basis.Z * _speed * (float)delta;
        }
        public override void _Process(double delta)
        {
            _timer.Tick((float)delta);
            if (_timer.IsReady())
            {
                BulletPool.Instance.ReturnToPool(this);
            }
        }
    }
}