using UnityEngine;
using UnityEditor;
using System;

namespace StateMachines
{
    public class StateManager : Singleton<StateManager>
    {
        public GameState currentState, previousState,afterLoadingState;
        public event Action<States> OnStateChanged;


        public void Start()
        {
            currentState =null;
            previousState = null;
            SetState(new LoadingState());
            
        }

        private void SetState(GameState state)
        {
            Debug.Log(state);
            if (currentState != null)
            {
                previousState = currentState;
                previousState.OnStateExit();
            }
            
            currentState = state;
            if (currentState != null)
            {
                //OnStateChanged.Invoke(currentState.stateName);
                currentState.OnStateEnter();
            }
        }
        public void ChangeState()
        {
            
            if (afterLoadingState == null)
            {
                SetState(new LobbyState());
            }else{
                 SetState(afterLoadingState);
            }
        }
        public void ChangeState(GameState state,bool isLoading)
        {
            if(isLoading){
                SetState(new LoadingState());
                afterLoadingState=state;
            }else{
                SetState(state);
            }

        }
    }
}