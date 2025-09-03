using UnityEngine;
using System.Collections.Generic;

public class EnemyStateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;
    public Dictionary<string, State> States = new Dictionary<string, State>();

    protected State CurrentState { get { return currentState; } set { currentState = value; } }

    void Awake()
    {
        State[] childrenStates = GetComponentsInChildren<State>();
        foreach (State state in childrenStates)
        {
            States.Add(state.name, state);
        }
        if (initialState is not null)
        {
            initialState.EnterStates();
            currentState = initialState;
        }
    }

    void Update()
    {
        if (currentState is not null)
        {
            currentState.ProcessStates();
        }
    }

    void FixedUpdate()
    {
        if (currentState is not null)
        {
            currentState.FixedProcessStates();
        }
    }

}
