using System;
using Godot;

namespace HealthSystem
{
    public interface IDamagable
    {
        void TakeDamage(float amount);
    }
    public partial class Health : Area3D, IDamagable
    {
        [Export] private float maxHealth = 100f;
        // [Signal] public Signal OnDeathEventHandler;
        // [Export] private UnityEvent OnTakeDamage;

        private float _currentHealth;
        private void OnEnable() => _currentHealth = maxHealth;

        public override void _Ready()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            // OnTakeDamage?.Invoke();
            // Debug.Log($"{gameObject.name} : {_currentHealth}");
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                GD.Print($"{GetParent().Name} Died");
                // Debug.Log($"{gameObject.name} Died");
                // OnDeath.Invoke();
            }
        }
    }
}