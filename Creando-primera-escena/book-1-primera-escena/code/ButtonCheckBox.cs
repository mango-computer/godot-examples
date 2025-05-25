using Godot;
using System;

public partial class ButtonCheckBox : CheckBox
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		// Initialization code here
		GD.Print("[ButtonCheckBox][ _Ready ] ButtonCheckBox node is ready.");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print($"[ButtonCheckBox][ _Process ] node is processing frame events. Delta: {delta}");
	}

	// Called when the button is pressed
	public override void _Pressed()
	{
		GD.Print("[ButtonCheckBox][ _Pressed ] ButtonCheckBox has been pressed.");
	}
}
