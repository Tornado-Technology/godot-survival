using Survival.Scripts.Components;
using Survival.Scripts.Entities;

namespace Survival.Scripts.Player;

public partial class PlayerEntity : Entity
{
	public override void _Ready()
	{
		AddComponent(new InputComponent());
		AddComponent(new CharacterAnimationSpritesComponent());
		AddComponent(new CharacterAnimatorComponent());
		AddComponent(new MoveComponent());
		AddComponent(new DamagableComponent());

		base._Ready();
	}
}
