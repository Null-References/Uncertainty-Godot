using Godot;

public partial class CameraArm : SpringArm3D
{

	[Export] float fallBehind = 0.1f;
	[Export] float mouseSpeed = 0.1f;
	[Export] Node3D parent;

	bool _captured;

	public void SetMouseCaptured(bool captured)
	{
		TopLevel = true;
		Input.MouseMode = captured ? Input.MouseModeEnum.Captured : Input.MouseModeEnum.Visible;
		_captured = captured;
	}

	public override void _Process(double delta)
	{
		Vector3 pos = Position;
		pos = pos.Lerp(parent.Position, fallBehind);
		Position = pos;
		if (!_captured)
		{
			Rotation = parent.Rotation;
		}

	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (_captured)
			if (@event is InputEventMouseMotion mouseMotion)
			{
				var rotation = RotationDegrees;
				rotation.X -= mouseMotion.Relative.Y * mouseSpeed;
				rotation.X = Mathf.Clamp(rotation.X, -90.0f, 30.0f);

				rotation.Y -= mouseMotion.Relative.X * mouseSpeed;
				rotation.Y = Mathf.Wrap(rotation.Y, 0.0f, 360.0f);

				RotationDegrees = rotation;
			}
	}


}