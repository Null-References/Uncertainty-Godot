using System.Collections.Generic;
using Godot;

namespace Utils
{
    public abstract partial class PoolBase<T> : Node where T : class,IPoolObject
    {
        [Export] private PackedScene obj { set; get; }

        public static PoolBase<T> Instance { get; private set; }

        protected Queue<T> _objects = new Queue<T>();

        public override void _Ready()
        {
            Instance = this;
        }


        public virtual void ReturnToPool(T returnObject)
        {
            returnObject.Disable();
            _objects.Enqueue(returnObject);
        }

        public virtual T Get()
        {
            if (_objects.Count < 1)
            {
                AddToPool(1);
            }
            var o = _objects.Dequeue();
            o.Enable();
            return o;
        }

        protected virtual void AddToPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var instance = obj.Instantiate();
                AddChild(instance);
                var newObject = instance as T;
                if (newObject == null)
                {
                    GD.PrintErr($"{obj.ResourceName} must implement IPoolObject ");
                    return;
                }
                _objects.Enqueue(newObject);
            }
        }
    }
}