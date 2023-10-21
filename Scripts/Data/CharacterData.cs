using Survival.Scripts.Origins;
using System;

namespace Survival.Scripts.Data;

[Serializable]
public struct CharacterData
{
	public string Name { get; set; }
	public string Description { get; set; }
	public CharacterGender Gender { get; set; }
	public OriginId OriginId { get; set; }
}

public enum CharacterGender
{
	Male,
	Female,
	No,
}

