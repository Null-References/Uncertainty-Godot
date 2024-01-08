using System;
using Godot;


namespace Controller
{
	public partial class ShipPhysicsController : Controller
	{
		[Export] Curve curve;

		InputHandler _input;
		RigidBody3D _rb;


		public Vector2 TorqueForceValue => _input.GetMouseValue();
		public float RollForceValue => _input.GetRollValue;

		public override void Disable() { }
		public override void Enable() { }
		public override void Update(double delta)
		{
			_movement.AddForce(-_rb.GlobalBasis.Z * _input.GetMoveValue);
			var mouse = _input.GetMouseValue();
			_movement.AddTorque(mouse.Y, mouse.X, _input.GetRollValue);
		}

		public override void SetDependency(RigidBody3D rb, Movement movement, InputHandler input)
		{
			_movement = movement;
			_input = input;
			_rb = rb;
		}

		//TODO: this is the value which determines how much the ship should rotate visually
		public float AnimatedRollValue()
		{
			return 0;
		}
	}
}
