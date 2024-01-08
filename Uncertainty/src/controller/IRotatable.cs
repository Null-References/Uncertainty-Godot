using Godot;

namespace Controller
{
    public interface IRotatable
    {
        RigidBody3D GetRigidBody();
        float GetRotationSpeed();
    }
}