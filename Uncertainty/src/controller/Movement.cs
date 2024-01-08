using Godot;

namespace Controller
{
	public class Movement
	{
		IMovable _movable;
		IRotatable _rotatable;

		public Movement(IMovable movable, IRotatable rotatable)
		{
			_movable = movable;
			_rotatable = rotatable;
		}

		public void AddForce(Vector3 direction) => _movable.GetRigidBody().ApplyForce(direction * _movable.GetMoveSpeed());
		public void AddTorque(float pitch, float yaw, float roll)
		{
			var _pitch = _rotatable.GetRigidBody().GlobalBasis.X * -pitch;
			var _yaw = _rotatable.GetRigidBody().GlobalBasis.Y * -yaw;
			var _roll = _rotatable.GetRigidBody().GlobalBasis.Z * roll;

			_rotatable.GetRigidBody().ApplyTorque((_pitch + _yaw + _roll) * _rotatable.GetRotationSpeed());
		}
		public void SetRotation(Quaternion quat, float speed)
		{
			var q = _rotatable.GetRigidBody().Quaternion;
			q = q.Slerp(quat, speed);
			_rotatable.GetRigidBody().Quaternion = q;
		}
	}
}
