using System;
using Godot;

namespace Sprite2D.Scripts;

public class SpriteMovement : Node2D
{
	private readonly float _movementSpeed = 100.0f;
	private readonly Random _rand = new();
	private Vector2 _basePosition;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_basePosition = Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void _Process(float delta)
	{
		var movement = new Vector2(_rand.Next(-1, 5), _rand.Next(-1, 5));
		movement = movement.Normalized() * _movementSpeed * delta;
		Position += movement;
	}
}
