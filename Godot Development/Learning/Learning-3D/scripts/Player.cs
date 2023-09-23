using Godot;

namespace Learning3D.scripts;

public partial class Player : CharacterBody3D
{	
	private float _currentSpeed = 5.0f;
	private const float WalkingSpeed = 5.0f;
	private const float SprintingSpeed = 10.0f;
	private const float CrouchingSpeed = 3.0f;
	private const float JumpVelocity = 4.5f;
	private const float MouseSense = 0.4f;
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float _gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	[Export]
	private NodePath _headPath; // This will store the path to the 'head' node.

	private Node3D _head; // This will store the reference to the 'head' node.

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion)
		{
			float rotationRadians = -Mathf.DegToRad(mouseMotion.Relative.X * MouseSense);
			RotateY(rotationRadians);
		}
	}
	
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;

		// Initialize the 'head' node using the path.
		_head = GetNode<Node3D>(_headPath);
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("sprint"))
		{
			_currentSpeed = SprintingSpeed;
		}
		// Check if the crouch action is pressed (and not sprinting).
		else if (Input.IsActionPressed("crouch"))
		{
			_currentSpeed = CrouchingSpeed;
		}
		else
		{
			_currentSpeed = WalkingSpeed;
		}

		var velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= _gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		var inputDir = Input.GetVector("left", "right", "forward", "backward");
		var direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * _currentSpeed;
			velocity.Z = direction.Z * _currentSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, _currentSpeed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, _currentSpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
