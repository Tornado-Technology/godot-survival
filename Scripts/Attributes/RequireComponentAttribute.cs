using System;
using System.Collections.Generic;

namespace Survival.Scripts.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class RequireComponentAttribute : Attribute
{
	private readonly Type[] _types;

	public IEnumerable<Type> Types => _types;

	public RequireComponentAttribute(Type type1)
	{
		_types = new Type[]
		{
			type1,
		};
	}

	public RequireComponentAttribute(Type type1, Type type2)
	{
		_types = new Type[]
		{
			type1,
			type2,
		};
	}

	public RequireComponentAttribute(Type type1, Type type2, Type type3)
	{
		_types = new Type[]
		{
			type1,
			type2,
			type3,
		};
	}
}
