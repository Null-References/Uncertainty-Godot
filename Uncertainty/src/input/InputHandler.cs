using System.Reflection;
using Godot;

public partial class InputHandler : Node
{
    [Export] Curve curve;
    [Export(PropertyHint.Range, "0,1,")] private float deadZoneRadius = 0.6f;
    [Export] private float deadZoneCoef = 3;

    [Signal]
    public delegate void ChangeControllerEventHandler();
    private bool _isFreeLook = false;
    public bool GetShootInput() => false;
    public bool GetAimingInput() => false;
    private void ToggleFreeLook() => _isFreeLook = !_isFreeLook;

    public Vector2 GetMouseValue()
    {
        if (_isFreeLook)
            return Vector2.Zero;

        Vector2 mouseVec = GetViewport().GetMousePosition();


        float height = GetViewport().GetVisibleRect().Size.Y / 2;
        float width = GetViewport().GetVisibleRect().Size.X;

        //to make the resulting vector in range [-1, 1]
        // ** assuming display is not vertical **
        mouseVec = new Vector2(mouseVec.X - (width / 2), mouseVec.Y - height) / height;

        mouseVec = mouseVec.LimitLength(curve.Sample(mouseVec.Length()));
        return mouseVec;
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("switch_controls"))
            EmitSignal(SignalName.ChangeController);
    }
    public float GetRollValue => Input.GetActionStrength("roll_left") - Input.GetActionStrength("roll_right");
    public float GetMoveValue => Input.GetActionStrength("forward") - Input.GetActionStrength("back");
    public Vector2 GetPanValue => new Vector2(Input.GetActionStrength("left") - Input.GetActionStrength("right"), Input.GetActionStrength("up") - Input.GetActionStrength("down"));
}