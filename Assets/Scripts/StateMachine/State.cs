using UnityEngine;
using System.Collections.Generic;

public abstract class State : MonoBehaviour
{


    public Entity entity;
    public StateMachine _machine;

    private bool _isRootState = false;
    private State _currentSubState;
    private State _currentSuperState;

    public StateMachine Machine { get { return _machine; } set { _machine = value; } }
    public bool IsRootState { get { return _isRootState; } set { _isRootState = value; } }
    public State CurrentSubState { get { return _currentSubState; } }
    public State CurrentSuperState { get { return _currentSuperState; } }

    void Awake()
    {
        _machine = GetComponentInParent<StateMachine>();
    }

    public abstract void Enter();

    public abstract void Exit();

    public abstract void Process();

    public abstract void FixedProcess();

    public abstract void InitializeSubState();

    public abstract void CheckSwitchStates();

    public void EnterStates()
    {
        Enter();
        if (_currentSubState != null)
        {
            _currentSubState.EnterStates();
        }
    }

    public void ExitStates()
    {
        Exit();
        if (_currentSubState != null)
        {
            _currentSubState.ExitStates();
        }
    }

    public void ProcessStates()
    {
        Process();
        if (_currentSubState != null)
        {
            _currentSubState.ProcessStates();
        }
    }

    public void FixedProcessStates()
    {
        FixedProcess();
        if (_currentSubState != null)
        {
            _currentSubState.FixedProcessStates();
        }
    }

    public void SwitchState(State newState)
    {
        //current state exits
        ExitStates();
        //new state enters
        newState.EnterStates();
        if (newState.IsRootState)
        {
            // switches current state
            _machine.currentState = newState;
        }
        else if (CurrentSuperState != null)
        {
            // set the current super states sub state to the new state
            CurrentSuperState.SetSubState(newState);
        }
    }

    public void SetSuperState(State newSuperState)
    {
        _currentSuperState = newSuperState;
    }

    public void SetSubState(State newSubState)
    {
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}