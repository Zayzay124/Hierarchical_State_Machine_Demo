using UnityEngine;

public class Phase3State : State
{
    public PatrolState patrolState;

    public Phase3State()
    {
        IsRootState = true;
    }

    public override void Enter()
    {
        Debug.Log("Entered Phase 3");
        InitializeSubState();
    }

    public override void Exit() { }

    public override void Process() { }

    public override void FixedProcess() { }

    public override void InitializeSubState()
    {
        SetSubState(_machine.States["Patrol"]);
    }

    public override void CheckSwitchStates() { }
}
