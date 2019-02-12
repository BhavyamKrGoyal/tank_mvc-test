using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;

namespace StateMachines
{
    public class StateManager : Singleton<StateManager>
    {
        public GameState currentState=null, previousState=null, afterLoadingState;
        public event Action<GameState> OnStateChanged;
        public void Start()
        {
            SetState(new LoadingState());
        }

        private void SetState(GameState state)
        {
            //Debug.Log(state);
            if (currentState != null)
            {
                previousState = currentState;
                previousState.OnStateExit();
            }
            currentState = state;
            OnStateChanged?.Invoke(currentState);
            if (currentState != null)
            {
                //OnStateChanged.Invoke(currentState.stateName);
                currentState.OnStateEnter();
            }
        }
        private void OnLevelWasLoaded(int level)
        {
            currentState.Update();

        }
        public void ChangeState()
        {

            if (previousState == null)
            {
               
                SetState(new LobbyState());
            }
            else
            {
                SetState(afterLoadingState);
            }
        }
        public void ChangeState(GameState state, bool isLoading)
        {
            //Debug.Log(isLoading);
            if (isLoading)
            {
                SetState(new LoadingState());
                afterLoadingState = state;
            }
            else
            {
                SetState(state);
            }

        }
    }
}