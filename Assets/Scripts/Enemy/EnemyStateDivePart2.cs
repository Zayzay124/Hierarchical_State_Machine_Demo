using UnityEngine;

public class EnemyDivePart2State : State
{
    private EnemyDiveState diveState;

    public override void Enter()
    {
        diveState = (EnemyDiveState)_machine.States["Dive"];
        Debug.Log("Entered Dive Phase2");
    }

    public override void Exit() { }

    public override void Process() { }

    public override void FixedProcess()
    {
        entity.transform.position = Vector2.MoveTowards(entity.transform.position, diveState.OriginPos, diveState.returnSpeed * Time.deltaTime);
        if ((Vector2)entity.transform.position == diveState.OriginPos)
        {
            CurrentSuperState.SwitchState(_machine.States["Patrol"]); // this is a solution
            //diveState.SwitchState(_machine.States["Patrol"]);
            //SwitchState(_machine.States["Patrol"]);
        }
    }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() { }

}
