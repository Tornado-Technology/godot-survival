using Godot;
using System.Collections.Generic;

namespace Survival.Scripts.Components;

public class CharacterAnimationSpritesComponent : Component
{
	private readonly List<AnimatedSprite2D> _animatedSprites = new List<AnimatedSprite2D>();

	public int Frame
	{
		get
		{
			return _animatedSprites[0].Frame;
		}

		set
		{
			foreach (var sprite in _animatedSprites)
			{
				sprite.Frame = value;
			}
		}
	}

	public override void Initialize()
	{
		base.Initialize();

		var characterBody = Owner.GetChild<CharacterBody2D>(0);
		var animationSprite = characterBody.GetChild<AnimatedSprite2D>(0);

		_animatedSprites.Add(animationSprite);
		_animatedSprites.Add(animationSprite.GetChild<AnimatedSprite2D>(0));
		_animatedSprites.Add(animationSprite.GetChild<AnimatedSprite2D>(1));
	}

	public override void Update(double delta)
	{
		base.Update(delta);

	}

	public void Play(string name)
	{
		foreach (var sprite in _animatedSprites)
		{
			sprite.Play(name);
		}
	}

	public void Pause()
	{
		foreach (var sprite in _animatedSprites)
		{
			sprite.Pause();
		}
	}
}
