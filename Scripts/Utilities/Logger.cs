using Godot;
using System;

namespace Survival.Scripts.Utilities;

public static class Logger
{
	public static void Debug(string message)
	{
		Print(message, LogLevel.Debug);
	}

	public static void Info(string message)
	{
		Print(message, LogLevel.Info);
	}

	public static void Warn(string message)
	{
		Print(message, LogLevel.Warn);
	}

	public static void Error(string message)
	{
		Print(message, LogLevel.Error);
	}

	private static void Print(string message, LogLevel level)
	{
		GD.Print($"[{Enum.GetName(level)}] {message}");
	}
}

enum LogLevel : byte
{
	Debug,
	Info,
	Warn,
	Error,
}