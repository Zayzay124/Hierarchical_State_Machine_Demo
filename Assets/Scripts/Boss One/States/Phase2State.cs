using UnityEngine;

public class Phase2State : State
{
    public PatrolState patrolState;

    public Phase2State()
    {
        IsRootState = true;
    }

    public override void Enter()
    {
        Debug.Log("Entered Phase 2");
        patrolState.AddBehavior("Crossbeam");
        InitializeSubState();
    }

    public override void Exit() { }

    public override void Process() { }

    public override void FixedProcess() { }

    public override void CheckSwitchStates() { }

    public override void InitializeSubState()
    {
        SetSubState(_machine.States["Patrol"]);
    }

}
