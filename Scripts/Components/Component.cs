using Godot;
using Survival.Scripts.Attributes;
using Survival.Scripts.Entities;
using Survival.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Survival.Scripts.Components;

public abstract class Component : IComponentResolver, IInitializable, IUpdatable, IPhysicsUpdatable, IInputable
{
	public Entity? Owner { get; private set; }
	public string Name => GetType().Name;

	public List<Type> RequireComponents
	{
		get
		{
			var result = new List<Type>();
			foreach (var attribute in RequireComponentAttributes)
			{
				result.AddRange(attribute.Types.ToList());
			}
			return result;
		}
	}

	private List<RequireComponentAttribute> RequireComponentAttributes => GetType().GetCustomAttributes(false).OfType<RequireComponentAttribute>().ToList();

	public void Added(Entity owner)
	{
		Owner = owner;
	}

	public virtual void Initialize()
	{
	}

	public virtual void Update(double delta)
	{
	}

	public virtual void PhysicsUpdate(double delta)
	{
	}

	public virtual void Input(InputEvent @event)
	{
	}

	public void AddComponent(Component component)
	{
		Owner.AddComponent(component);
	}

	public void RemoveComponent<T>() where T : Component
	{
		Owner.RemoveComponent<T>();
	}

	public bool TryRemoveComponent<T>() where T : Component
	{
		return Owner.TryRemoveComponent<T>();
	}

	public void RemoveAllComponents<T>() where T : Component
	{
		Owner.RemoveAllComponents<T>();
	}

	public bool HasComponent<T>() where T : Component
	{
		return Owner.HasComponent<T>();
	}

	public T GetComponent<T>() where T : Component
	{
		return Owner.GetComponent<T>();
	}

	public List<T> GetComponents<T>() where T : Component
	{
		return Owner.GetComponents<T>();
	}

	public bool TryGetComponent<T>([NotNullWhen(true)] out T component) where T : Component
	{
		return Owner.TryGetComponent(out component);
	}

	public int CountComponents<T>() where T : Component
	{
		return Owner.CountComponents<T>();
	}
}
