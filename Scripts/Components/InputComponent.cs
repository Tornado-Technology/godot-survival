using Godot;

namespace Survival.Scripts.Components;

public class InputComponent : Component
{
	public Vector2 Direction { get; private set; } = Vector2.Zero;

	public override void Update(double delta)
	{
		base.Update(delta);

		Direction = Godot.Input.GetVector("left", "right", "up", "down").Normalized();
	}
}
