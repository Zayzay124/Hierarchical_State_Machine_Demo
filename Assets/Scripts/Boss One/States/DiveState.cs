using UnityEngine;

public class DiveState : State
{
    private Vector2 originPos;
    private Vector2 targetPos;

    public float diveSpeed;
    public float returnSpeed;
    public float waitTime = 0.5f;

    public Vector2 OriginPos { get { return originPos; } }
    public Vector2 TargetPos { get { return targetPos; } }

    public override void Enter()
    {
        originPos = entity.transform.position;
        targetPos = entity.GetComponent<BirdBoss>().Player.transform.position;
        //targetPos = entity.Player.transform.position;
        Debug.Log("Entered Dive State");
        InitializeSubState();
    }

    public override void Exit()
    {
        Debug.Log("Fully Exited");
    }

    public override void Process() { }

    public override void FixedProcess() { }

    public override void InitializeSubState()
    {
        SetSubState(_machine.States["DivePart1"]);
    }

    public override void CheckSwitchStates() { }

}
