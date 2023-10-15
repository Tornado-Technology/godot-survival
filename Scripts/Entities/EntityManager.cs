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

	public override void _Ready()
	{
		base._Ready();

		SpawnEntity(new PlayerEntity());

		foreach (var entity in Entities)
		{
			entity.Initialize();
		}
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		foreach (var entity in Entities)
		{
			entity.Update(delta);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		foreach (var entity in Entities)
		{
			entity.PhysicsUpdate(delta);
		}
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		foreach (var entity in Entities)
		{
			entity.Input(@event);
		}
	}
}
