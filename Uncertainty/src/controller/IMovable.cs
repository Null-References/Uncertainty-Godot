using Godot;

namespace Controller
{
    public interface IMovable
    {
        RigidBody3D GetRigidBody();
        float GetMoveSpeed();
    }
}