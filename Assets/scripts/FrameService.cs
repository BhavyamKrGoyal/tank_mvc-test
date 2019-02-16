using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;

public class FrameService : SingletonScene<FrameService>
{
    // Start is called before the first frame update
    int frame = -0;
    bool isPause = false;
    void Start()
    {
        StateManager.Instance.OnStateChanged += OnStateChanged;
    }
    public void OnStateChanged(GameState state)
    {
        if (state is GamePauseState)
        {
            isPause = true;
        }
        else
        {
            if((state is GameReplayState) && !(StateManager.Instance.previousState is GamePauseState)){
                frame=0;
                Debug.Log("HEy there mate I reset the frame");
            }
            isPause = false;
        }
    }
    private void OnDisable()
    {
        StateManager.Instance.OnStateChanged -= OnStateChanged;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isPause)
        {
            ++frame;
        }
    }
    public int GetFrame(){
        return frame;
    }
}
