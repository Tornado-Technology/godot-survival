using Godot;
using Survival.Scripts.Components;
using Survival.Scripts.Interfaces;
using Survival.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Survival.Scripts.Entities;

public abstract class Entity : IComponentResolver, IInitializable, IUpdatable, IPhysicsUpdatable, IInputable
{
	public EntityUid Uid;

	private List<Component> _components = new List<Component>();

	public IEnumerable<Component> Components => _components;

	public void Added(EntityUid uid)
	{
		Uid = uid;
	}

	public virtual void Initialize()
	{
		foreach (var component in _components)
		{
			component.Initialize();
		}
	}

	public virtual void Update(double delta)
	{
		foreach (var component in _components)
		{
			component.Update(delta);
		}
	}
	
	public virtual void PhysicsUpdate(double delta)
	{
		foreach (var component in _components)
		{
			component.PhysicsUpdate(delta);
		}
	}

	public virtual void Input(InputEvent @event)
	{
		foreach (var component in _components)
		{
			component.Input(@event);
		}
	}

	public void AddComponent(Component component)
	{
		foreach (var type in component.RequireComponents)
		{
			if (!type.IsSubclassOf(typeof(Component)))
				continue;

			if ((bool)GetType().GetMethod(nameof(HasComponent)).MakeGenericMethod(type).Invoke(this, null))
				continue;

			throw new Exception($"Component {type.Name} is required for component {component.Name}, but it is not present on entity {Uid}");
		}

		component.Added(this);
		_components.Add(component);

		Logger.Debug($"Component {component.Name} is added to entity {Uid}");
	}

	public void RemoveComponent<T>() where T : Component
	{
		var components = GetComponents<T>();
		if (components.Count == 0)
			throw new IndexOutOfRangeException();

		components.RemoveAt(components.IndexOf(components[0]));
	}

	public bool TryRemoveComponent<T>() where T : Component
	{
		var components = GetComponents<T>();
		if (components.Count == 0)
			return false;

		return components.Remove(components[0]);
	}

	public void RemoveAllComponents<T>() where T : Component
	{
		_components.RemoveAll((comp) => comp is  T);
	}

	public bool HasComponent<T>() where T : Component
	{
		return CountComponents<T>() > 0;
	}

	public T GetComponent<T>() where T : Component
	{
		var components = GetComponents<T>();
		if (components.Count == 0)
			throw new IndexOutOfRangeException();

		return components[0];
	}

	public List<T> GetComponents<T>() where T : Component
	{
		return _components.OfType<T>().ToList();
	}

	public bool TryGetComponent<T>([NotNullWhen(true)] out T? component) where T : Component
	{
		component = null;

		var components = GetComponents<T>();
		if (components.Count == 0)
			return false;

		component = components[0];
		return true;
	}

	public int CountComponents<T>() where T : Component
	{
		return GetComponents<T>().Count;
	}
}
