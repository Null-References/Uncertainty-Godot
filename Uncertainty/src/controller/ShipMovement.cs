using Godot;

namespace Controller
{

	public partial class ShipMovement : RigidBody3D, IMovable, IRotatable
	{
		[Export] Node3D shipModel;
		[Export] float moveSpeed = 1;
		[Export] float rotateSpeed = 1;
		[Export] ControllerContext controllerContext;

		Movement _movement;

		public override void _Ready()
		{
			_movement = new Movement(this, this);
			controllerContext.SetUpControllers(this, _movement);
			controllerContext.SwitchController();
		}


		public override void _PhysicsProcess(double delta)
		{
			base._PhysicsProcess(delta);
			controllerContext.Update(delta);
		}

		public RigidBody3D GetRigidBody() => this;

		public float GetMoveSpeed() => moveSpeed;

		public float GetRotationSpeed() => rotateSpeed;

	}
}
