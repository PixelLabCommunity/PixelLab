using Godot;

namespace Sprite2D.scripts;

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
		PixelMovement();
	}

	private void PixelMovement()
	{
		if (Input.IsKeyPressed(Key.W)) Position += new Vector2(_baseX, -_positionY);
		if (Input.IsKeyPressed(Key.S)) Position += new Vector2(_baseX, _positionY);

		if (Input.IsKeyPressed(Key.A)) Position += new Vector2(-_positionX, _baseY);
		if (Input.IsKeyPressed(Key.D)) Position += new Vector2(_positionX, _baseY);
	}
}
