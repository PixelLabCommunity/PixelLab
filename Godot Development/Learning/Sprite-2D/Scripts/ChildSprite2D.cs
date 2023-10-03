using Godot;

namespace Sprite2D.Scripts;

public partial class ChildSprite2D :Sprite2D
{
	private Vector2 _basePosition;
	private float _baseX;
	private float _baseY;
	private float _positionX = 5.0f;
	private float _positionY = 5.0f;


	public override void  _Ready()
	{
		_basePosition = Position;
	}


	public override void _Process(double delta)
	{
		ChildPixelMovement();
	}
	
	private void ChildPixelMovement()
	{
		if (Input.IsKeyPressed(Key.Y)) Position += new Vector2(_baseX, -_positionY);
		if (Input.IsKeyPressed(Key.H)) Position += new Vector2(_baseX, _positionY);

		if (Input.IsKeyPressed(Key.T)) Position += new Vector2(-_positionX, _baseY);
		if (Input.IsKeyPressed(Key.U)) Position += new Vector2(_positionX, _baseY);
	}
	
	
}
