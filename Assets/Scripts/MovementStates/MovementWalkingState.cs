using UnityEngine;

public class MovementWalkingState : MovementBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("Walk", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("Walk", false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        UpdateWalkAnimation();
        CheckFalling();
        HandleMouseInput();
        HandleJumpInput();
        CheckStateTransition();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rig.AddForce(rig.velocity * -0.5f, ForceMode2D.Impulse);
            stateMachine.SetNextStateToMain();
        }
    }

    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.SetNextState(new MovementJumpState());

    }

    private void CheckFalling()
    {
        if (!Physics2D.OverlapBox(rig.transform.position, new Vector2(0.63f, 0.093f), 0))
        {
            animator.SetFloat("fallSpeed", rig.velocity.y);
            stateMachine.SetNextState(new MovementFallingState());
        }
    }

    private void UpdateWalkAnimation()
    {
        if((Mathf.Abs(movement) > 0.01f && !animator.GetBool("Walk")))
            animator.SetBool("Walk", true);
        else if(Mathf.Abs(movement) < 0.01f)
            animator.SetBool("Walk", false);
    }

    private void CheckStateTransition()
    {
        if (rig.velocity.x == 0 && movement == 0)
        {
            stateMachine.SetNextStateToMain();
        }
    }

    public override void Move()
    {
        base.Move();
    }
}
