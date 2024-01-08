using Godot;


namespace Controller
{
    public partial class ShipCameraController : Controller
    {
        [Export] CameraArm camera;
        [Export] Curve curve;
        [Export] float turnSpeed = 1;

        InputHandler _input;
        RigidBody3D _rb;

        public override void Enable()
        {
            camera.SetMouseCaptured(true);
            camera.Quaternion = Quaternion.Identity;
        }
        public override void Disable()
        {
            camera.SetMouseCaptured(false);
            camera.Rotation = Vector3.Zero;
        }
        public override void Update(double delta)
        {
            _movement.AddForce(-_rb.GlobalBasis.Z * _input.GetMoveValue);

            float diff = camera.GlobalBasis.Z.AngleTo(_rb.GlobalBasis.Z);
            diff = Mathf.RadToDeg(diff);
            if (diff < 1f)
                diff = 1;

            float changerate = curve.Sample(diff / 180);

            float w = Mathf.Clamp(changerate * (turnSpeed / diff) * Mathf.Abs(_input.GetMoveValue), 0, 1);
            _movement.SetRotation(camera.Quaternion, w);
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
