using UnityEngine;

public class MovementJumpState : MovementBaseState
{
    private float duration;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        duration = comboCharacter.Player.jumpTimeToApex;
        animator.SetTrigger("Jump");
        rig.AddForce(new Vector2(0, comboCharacter.Player.jumpForce), ForceMode2D.Impulse);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (duration < 0 || rig.velocity.y <= 0)
        {
            stateMachine.SetNextState(new MovementFallingState());
        }
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
    }

    public override void OnUpdate()
    {
        duration -= Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rig.gravityScale = comboCharacter.Player.gravityScale * comboCharacter.Player.jumpCutGravityMult;
            stateMachine.SetNextState(new MovementFallingState());
        }
        base.OnUpdate();
    }
}