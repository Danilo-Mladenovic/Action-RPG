using Godot;
using System;

public class Player : KinematicBody2D
{

    private Vector2 velocity;
    private int MAX_SPEED = 150;
    private int ACCELERATION = 50;
    private float FRICTION = 25;

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
        {
            velocity += inputVector * ACCELERATION * delta;
            velocity = velocity.Clamped(MAX_SPEED * delta);
        }
        else
            velocity = velocity.MoveToward(Vector2.Zero, FRICTION * delta);

        MoveAndCollide(velocity);
    }
}
