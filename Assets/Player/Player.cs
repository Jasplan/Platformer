using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:

    int gravity = 0;
    Vector2 inputDirection = Vector2.Zero;
    Vector2 mousPos = Vector2.Zero;
    Vector2 UP = Vector2.Zero; 
    
    AnimationPlayer animator = null;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animator = GetNode<AnimationPlayer>("Animation");
        UP.x = 0;
        UP.y = -1;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
        

        Boolean inputMagnitude = false;

        mousPos = GetLocalMousePosition();


        //movement
        inputDirection.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        inputDirection.x *= 100;
        
        

        if(IsOnFloor()){
            gravity = 0;
            if(Input.IsActionJustPressed("ui_up")){
                gravity = -200;
            }
            if (inputDirection.x <= 0 ){
                animator.Play("WalkLeft");
                
            }
            else if(inputDirection.x >= 0){
                animator.Play("WalkRight");
                
            }

        }
        else if(!IsOnFloor()){
            gravity += 2;
            if(IsOnCeiling() && gravity < 0){
                gravity = 0;
            }
        }



        
        inputDirection.y = gravity;
        MoveAndSlide(inputDirection, UP);
    }
}
