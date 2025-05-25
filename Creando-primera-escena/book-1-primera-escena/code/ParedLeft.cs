using Godot;
using System;

public partial class ParedLeft : RigidBody2D
{

	public ParedLeft()
	{
		GD.Print("[ParedLeft][ Constructor ]  first events.");
	}

	// Over write_init method
	public override void _EnterTree()
	{
		base._EnterTree();
		GD.Print("[ParedLeft][ _EnterTree ] Pared_left node is entering the scene tree.");
	}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		GD.Print("[ParedLeft][ _Ready ] Pared_left node is ready.");
	}

	public override void _Input(InputEvent e)
	{
		GD.Print($"[ParedLeft][ _Input ] node is processing input events. {e.AsText()}");
		//GetViewport().SetInputAsHandled();
	}

	public override void _UnhandledInput(InputEvent @event)
    {
		GD.Print($"[ParedLeft][ _UnhandledInput ] node is processing unhandled input events. {@event.AsText()}");

		if (Input.IsActionPressed("ui_right"))
		{
			GD.Print($"[ParedLeft][ _UnhandledInput ] ui_right.");
		}
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		GD.Print($"[ParedLeft][ _Process ] node is processing frame events. Delta: {delta}");
		if (Input.IsActionPressed("ui_right"))
		{
			GD.Print($"[ParedLeft][ _Process ] ui_right.");
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		GD.Print($"[ParedLeft][ _PhysicsProcess ] node is processing physics events. Delta: {delta}");
		if (Input.IsActionPressed("ui_right"))
		{
			GD.Print($"[ParedLeft][ _PhysicsProcess ] ui_right.");
		}
	}


}
