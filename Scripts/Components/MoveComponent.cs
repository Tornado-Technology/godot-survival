using Godot;
using Survival.Scripts.Attributes;

namespace Survival.Scripts.Components;

[RequireComponent(typeof(InputComponent))]
public class MoveComponent : Component
{
	private float _movementSpeed = 200f;

	private InputComponent _input;
	private CharacterBody2D _characterBody;

	public override void Initialize()
	{
		base.Initialize();

		_input = GetComponent<InputComponent>();

		_characterBody = Owner.GetChild<CharacterBody2D>(0);
	}

	public override void PhysicsUpdate(double delta)
	{
		base.PhysicsUpdate(delta);

		_characterBody.Velocity = _movementSpeed * _input.Direction;
		_characterBody.MoveAndSlide();
	}
}
