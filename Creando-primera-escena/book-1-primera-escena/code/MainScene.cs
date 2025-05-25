using Godot;
using System;

public partial class MainScene : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        GD.Print("[MainScene][ _Ready ] MainScene node is ready.");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        base._Process(delta);
        GD.Print($"[MainScene][ _Process ] node is processing frame events. Delta: {delta}");
    }

    // Input event handler
    public override void _Input(InputEvent e)
    {
        base._Input(e);
        GD.Print($"[MainScene][ _Input ] node is processing input events. {e.AsText()}");
    }

}
