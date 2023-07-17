using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{
    private StateMachine MeleeStateMachine;
    [SerializeField] public Collider2D hitbox;
    [SerializeField] public GameObject Hiteffect;
    [SerializeField] public PlayerData Player;
    [SerializeField] public Rigidbody2D rig;

    void Start()
    {
        MeleeStateMachine = GetComponent<StateMachine>();
        rig = GetComponent<Rigidbody2D>();
        rig.gravityScale = Player.gravityScale;
    }

    void Update()
    {
        if(MeleeStateMachine.CurrentState != null && MeleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
            rig.gravityScale = Player.gravityScale;
        if (Input.GetMouseButton(0) && MeleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            MeleeStateMachine.SetNextState(new MeleeEntryState());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && MeleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            MeleeStateMachine.SetNextState(new MovementEntryState());
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 && MeleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            MeleeStateMachine.SetNextState(new MovementEntryState());
        }
    }
}
