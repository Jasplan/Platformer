using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    
    Vector2 mousPos = Vector2.Zero;



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Vector2 inputDirection = Vector2.Zero;
        Boolean inputMagnitude = false;

        mousPos = GetLocalMousePosition();


        //movement
        inputDirection.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        inputDirection.x *= 100;
        MoveAndSlide(inputDirection);
    }
}
