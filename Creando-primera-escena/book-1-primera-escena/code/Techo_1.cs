using Godot;
using System;

public partial class Techo_1 : RigidBody2D
{

	private bool _isPrinted = false;

	// Over write_init method
	public override void _EnterTree()
	{
		base._EnterTree();
		// Inicializaciones tempranas o conexión de señales.
		//GD.Print("Techo_1 node is entering the scene tree.");
	}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		// Inicializaciones tardías o conexiones de señales.
		//GD.Print("Techo_1 node is ready.");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
		// Lógica de juego que necesita ejecutarse cada frame.
		if (!_isPrinted)
		{
			//GD.Print("Techo_1 node is processing for the first time.");
			_isPrinted = true;
		}
	}


}
