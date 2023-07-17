using UnityEngine;

public class MovementBaseState : State
{
    public Animator animator;
    public Rigidbody2D rig;
    public ComboCharacter comboCharacter;

    public float maxVelocity;
    public float acceleration;
    public float deceleration;

    public float movement;
    public bool facingRight;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        comboCharacter = GetComponent<ComboCharacter>();

        maxVelocity = comboCharacter.Player.runMaxVelocity;
        acceleration = comboCharacter.Player.runAcceleration;
        deceleration = comboCharacter.Player.runDecceleration;

        facingRight = rig.transform.localScale.x == 1;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        movement = Input.GetAxisRaw("Horizontal");

        if (movement != 0)
        {
            CheckDirection(movement > 0);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        Move();
    }

    public virtual void Move()
    {
        float targetVelocity = movement * maxVelocity;
        float accelRate = Mathf.Abs(targetVelocity) > 0.01f ? acceleration : deceleration;
        float velocityDifference = targetVelocity - rig.velocity.x;
        float movementForce = velocityDifference * accelRate;
        rig.AddForce(Vector2.right * movementForce, ForceMode2D.Force);
    }

    private void CheckDirection(bool lookingRight)
    {
        if (lookingRight != facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = rig.transform.localScale;
        scale.x *= -1;
        rig.transform.localScale = scale;
        facingRight = !facingRight;
    }
}