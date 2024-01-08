using Godot;
namespace Controller
{
	public partial class ControllerContext : Node
	{
		[Export] Controller[] controllers;
		[Export] InputHandler input;

		int _currentController = -1;
		public void SwitchController()
		{
			if (controllers.Length < 0) return;

			if (_currentController != -1)
				controllers[_currentController].Disable();

			_currentController = (_currentController + 1) % controllers.Length;
			controllers[_currentController].Enable();
		}
		public void SetUpControllers(RigidBody3D ship, Movement movement)
		{
			foreach (var c in controllers)
			{
				c.SetDependency(ship, movement, input);
			}
		}

		public void Update(double delta)
		{
			controllers[_currentController].Update(delta);
		}

	}
}
