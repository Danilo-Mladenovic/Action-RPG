using Godot;
using System;

public class Player : KinematicBody2D
{

    private Vector2 velocity;
    private int MAX_SPEED = 150;
    private int ACCELERATION = 300;
    private float FRICTION = 300;

    public override void _Ready()
    {
        velocity = Vector2.Zero;
    }

    public override void _PhysicsProcess(float delta)
    {
        Vector2 inputVector = Vector2.Zero;
        inputVector.x = 2 * (Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left"));
        inputVector.y = 2 * (Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up"));
        inputVector = inputVector.Normalized();

        if (inputVector != Vector2.Zero)
            velocity = velocity.MoveToward(inputVector * MAX_SPEED, ACCELERATION * delta);
        else
            velocity = velocity.MoveToward(Vector2.Zero, FRICTION * delta);

        velocity = MoveAndSlide(velocity);
    }
}
