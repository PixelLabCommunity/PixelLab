using Godot;

namespace Sprite2D.Scripts;

public partial class Sprite2D : Godot.Sprite2D
{
	private Vector2 _basePosition;
	private float _baseX;
	private float _baseY;
	private float _positionX = 5.0f;
	private float _positionY = 5.0f;


	public override void _Ready()
	{
		_basePosition = Position;
	}

	public override void _Process(double delta)
	{
		PixelMovementKeys();
		// LegacyMovement();
	}

	private void PixelMovementKeys()
	{
		var child = GetNode<Godot.Sprite2D>("ChildSprite2D");
		var secondChild = GetNode<Godot.Sprite2D>("SecondChildSprite2D");

		if (Input.IsActionPressed("ui_up") || Input.IsActionPressed("up"))
		{
			Position += new Vector2(_baseX, -_positionY);
			child.GlobalPosition = new Vector2(_baseX, _baseY);
		}


		if (Input.IsActionPressed("ui_down") || Input.IsActionPressed("down"))
		{
			Position += new Vector2(_baseX, _positionY);
			secondChild.GlobalPosition = new Vector2(_positionX, -_positionY);
		}


		if (Input.IsActionPressed("ui_left") || Input.IsActionPressed("left"))
			Position += new Vector2(-_positionX, _baseY);
		if (Input.IsActionPressed("ui_right") || Input.IsActionPressed("right"))
			Position += new Vector2(_positionX, _baseY);
	}

	private void LegacyMovement()
	{
		if (Input.IsActionPressed("ui_up") || Input.IsActionPressed("up"))
			Position += new Vector2(_baseX, -_positionY);
		if (Input.IsActionPressed("ui_down") || Input.IsActionPressed("down"))
			Position += new Vector2(_baseX, _positionY);

		if (Input.IsActionPressed("ui_left") || Input.IsActionPressed("left"))
			Position += new Vector2(-_positionX, _baseY);
		if (Input.IsActionPressed("ui_right") || Input.IsActionPressed("right"))
			Position += new Vector2(_positionX, _baseY);
	}
}
