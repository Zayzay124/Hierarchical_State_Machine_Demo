using Unity.VisualScripting;
using UnityEngine;

public class Phase1State : State
{
    public Phase1State()
    {
        IsRootState = true;
    }

    public override void Enter()
    {
        Debug.Log("Entered Phase 1 State");
        InitializeSubState();
    }

    public override void Exit() { }

    public override void Process()
    {
        CheckSwitchStates();
    }

    public override void FixedProcess() { }

    public override void InitializeSubState()
    {
        SetSubState(_machine.States["Patrol"]);
    }

    public override void CheckSwitchStates() { }
}