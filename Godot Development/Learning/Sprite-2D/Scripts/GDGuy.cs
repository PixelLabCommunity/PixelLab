using Godot;

namespace Sprite2D.Scripts;

public partial class GDGuy : Sprite2D
{
	private readonly float _timerStart = 1.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var callable = new Callable(this, "_onTimeout");
		var timer = GetNode<Timer>("Clock");
		timer.WaitTime = _timerStart;
		timer.Connect("timeout", callable);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Your update logic here
	}

	private void _onTimeout()
	{
		float randX = GD.RandRange(0, 500);
		float randY = GD.RandRange(0, 500);
		Position = new Vector2(randX, randY);
	}
}
