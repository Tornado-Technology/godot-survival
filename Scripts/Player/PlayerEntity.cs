using Survival.Scripts.Components;
using Survival.Scripts.Entities;

namespace Survival.Scripts.Player;

public class PlayerEntity : Entity
{
	public override void Initialize()
	{
		AddComponent(new InputComponent());
		AddComponent(new InputMoveComponent());

		base.Initialize();
	}
}
