using Godot;
using System;

public partial class ParedRight: RigidBody2D
{
	// Called when the node enters the scene tree for the first time.

	public ParedRight()
	{
		// Constructor
		// Aquí puedes inicializar variables o estados.
		GD.Print("[ParedRight][ Constructor ]  first events.");
	}

	// Over write_init method
	public override void _EnterTree()
	{
		base._EnterTree();
		// Inicializaciones tempranas o conexión de señales.
		GD.Print("[ParedRight][ _EnterTree ] ParedRight node is entering the scene tree.");
	}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		// Inicializaciones tardías o conexiones de señales.
		GD.Print("[ParedRight][ _Ready ] ParedRight node is ready.");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
		// Lógica de juego que necesita ejecutarse cada frame.
	}
}
