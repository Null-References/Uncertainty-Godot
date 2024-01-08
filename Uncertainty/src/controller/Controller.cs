using Godot;
namespace Controller
{
	public abstract partial class Controller : Node
	{
		protected Movement _movement;
		public abstract void Enable();
		public abstract void Disable();
		public abstract void SetDependency(RigidBody3D rb, Movement movement, InputHandler input);
		public abstract void Update(double delta);
	}
}
