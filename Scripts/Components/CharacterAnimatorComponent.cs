using Godot;
using Survival.Scripts.Attributes;

namespace Survival.Scripts.Components;

[RequireComponent(typeof(CharacterAnimationSpritesComponent))]
public class CharacterAnimatorComponent : Component
{
	private CharacterAnimationSpritesComponent _animation;

	private CharacterBody2D _characterBody;

	public override void Initialize()
	{
		base.Initialize();

		_animation = GetComponent<CharacterAnimationSpritesComponent>();

		_characterBody = Owner.GetChild<CharacterBody2D>(0);
	}

	public override void PhysicsUpdate(double delta)
	{
		base.PhysicsUpdate(delta);

		if (_characterBody.Velocity.X > 0)
			_animation.Play("walkRight");
		else if (_characterBody.Velocity.X < 0)
			_animation.Play("walkLeft");

		if (_characterBody.Velocity.Y > 0)
			_animation.Play("walkUp");
		else if (_characterBody.Velocity.Y < 0)
			_animation.Play("walkDown");

		if (_characterBody.Velocity == Vector2.Zero)
		{
			_animation.Frame = 0;
			_animation.Pause();
		}
	}
}
