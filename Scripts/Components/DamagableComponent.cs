using System;

namespace Survival.Scripts.Components;

public class DamagableComponent : Component
{
	public float Health
	{
		get => _health;
		private set => Math.Clamp(value, 0f, MaxHealth);
	}

	public float MinHealth;
	public float MaxHealth;

	public float Precent => Health / MaxHealth;

	public event Action OnTakeDamage;
	public event Action OnHeal;

	private float _health;

	public void Heal(float heal)
	{
		if (heal < 0)
			throw new ArgumentOutOfRangeException();

		Health += heal;
		OnHeal?.Invoke();
	}

	public void Damage(float damage)
	{
		if (damage < 0)
			throw new ArgumentOutOfRangeException();

		Health -= damage;
		OnTakeDamage?.Invoke();
	}
}
