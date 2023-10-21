using Godot;
using Survival.Scripts.Interfaces;
using Survival.Scripts.Player;
using System.Collections.Generic;
using System.Linq;

namespace Survival.Scripts.Entities;

public partial class EntityManager : Node2D
{
	public readonly List<Entity> Entities = new List<Entity>();

	protected int NextEntityUid { get; private set; } = (int)EntityUid.FirstUid;

	/// <summary>
	///     Factory for generating a new EntityUid for an entity currently being created.
	/// </summary>
	private EntityUid GenerateEntityUid()
	{
		return new EntityUid(NextEntityUid++);
	}

	public Entity SpawnEntity(Entity entity)
	{
		entity.Added(GenerateEntityUid());
		Entities.Add(entity);
		return entity;
	}

	public Entity GetEntity(EntityUid uid)
	{
		return Entities.Find((entity) => entity.Uid == uid);
	}

	public List<T> GetEntities<T>() where T : Entity
	{
		return Entities.OfType<T>().ToList();
	}
}
