using Survival.Scripts.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Survival.Scripts.Interfaces;

public interface IComponentResolver
{
	public void AddComponent(Component component);
	public void RemoveComponent<T>() where T : Component;
	public bool TryRemoveComponent<T>() where T : Component;
	public void RemoveAllComponents<T>() where T : Component;
	public bool HasComponent<T>() where T : Component;
	public T GetComponent<T>() where T : Component;
	public List<T> GetComponents<T>() where T : Component;
	public bool TryGetComponent<T>([NotNullWhen(true)] out T? component) where T : Component;
	public int CountComponents<T>() where T : Component;
}
