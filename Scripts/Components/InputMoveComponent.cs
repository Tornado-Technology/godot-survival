using Godot;
using Survival.Scripts.Attributes;
using Survival.Scripts.Utilities;

namespace Survival.Scripts.Components;

[RequireComponent(typeof(InputComponent))]
public class InputMoveComponent : Component
{
	private float _movementSpeed = 200f;

	private InputComponent _input;
	private CharacterBody2D _characterBody;

	public override void Initialize()
	{
		base.Initialize();

		_input = GetComponent<InputComponent>();
	}

	public override void PhysicsUpdate(double delta)
	{
		base.PhysicsUpdate(delta);
	}
}
