using System.Collections;
using System.Collections.Generic;
using Player;
using Replay_Service;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : Singleton<InputManager>
{
    //public int initialFame, pauseFrame, resumeFrame;
    public Dictionary<Controls, Queue<InputData>> playerInput = new Dictionary<Controls, Queue<InputData>>();
    public GameObject InputControllersPrefab, referenceInput;
    public Dictionary<Controls, List<InputComponent>> inputComponents = new Dictionary<Controls, List<InputComponent>>();
    bool userControls = true, replay = false, pause = false;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {

        StateManager.Instance.OnStateChanged += GameStateChanged;

        GameApplication.Instance.OnPlayerSpawn += AddPlayerListener;
    }
    public void SetQueue(Dictionary<Controls, Queue<InputData>> Pinput)
    {
        playerInput = Pinput;
        //Debug.Log(playerInput.Count);
        //Debug.Log(playerInput[Controls.IJKL].Peek().frame);

        // foreach (Controls controls in Pinput.Keys)
        // {
        //     for (int i = 0; i < Pinput[controls].Count; i++)
        //     {
        //         playerInput[controls].Enqueue(Pinput[controls][i]);
        //     }
        // }
    }

    public void EnqueueData(InputData inputdata, Controls controls)
    {
        if (Instance.playerInput.ContainsKey(controls))
        {
            //ServiceReplay.Instance.RecordInput(inputdata, controls);
            Instance.playerInput[controls].Enqueue(inputdata);
        }
    }
    public void Update()
    {

        if (!pause)
        {Debug.Log(replay);
            foreach (Controls controls in InputManager.Instance.inputComponents.Keys)
            {

                foreach (InputComponent inputComponent in inputComponents[controls])
                {
                    if (Instance.playerInput[controls].Count > 0)
                    {
                        //
                        // if (replay)
                        // {
                        //         Debug.Log("current: " + (Time.frameCount - initialFame) + "input: " + Instance.playerInput[controls].Peek().frame);
                        // }
                        if ((FrameService.Instance.GetFrame()) == (Instance.playerInput[controls].Peek().frame))
                        {

                            //Debug.Log(InputManager.Instance.playerInput[Controls.IJKL].forward);
                            //Debug.Log("try moving");
                            inputComponent.InputUpdate(Instance.playerInput[controls].Dequeue());
                        }
                        else
                        {
                            while (Instance.playerInput[controls].Count > 0 && (FrameService.Instance.GetFrame()) >= Instance.playerInput[controls].Peek().frame)
                            {
                                //Debug.Log("removing");
                                inputComponent.InputUpdate(Instance.playerInput[controls].Dequeue());
                            }
                        }

                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
             playerInput = new Dictionary<Controls, Queue<InputData>>();

            if (userControls)
            {
                referenceInput = Instantiate(InputControllersPrefab);
            }
        }
    }
    public void GameStateChanged(GameState currentState)
    {
        if (currentState is GamePlayState)
        {
            pause=false;
            // Debug.Log("gameplaystate");
            userControls = true;
            replay = false;
            if (referenceInput != null)
            {
                referenceInput.SetActive(true);
            }
        }
        else
        {
            if (referenceInput != null)
            {
                referenceInput.SetActive(false);
            }
            userControls = false;
            if (currentState is GameReplayState)
            {pause=false;
                if (StateManager.Instance.previousState is GamePauseState)
                {
                    pause = true;
                }
                replay = true;
                // initialFame = Time.frameCount;
            }
            if (currentState is GamePauseState)
            {
                pause = true;
                if (StateManager.Instance.previousState is GameReplayState)
                {
                    replay = false;
                }
            }
            else
            {
                pause = false;
            }
        }
    }

    public void RegisterInputComponent(InputComponent inputComponent, Controls controls)
    {
        if (!InputManager.Instance.inputComponents.ContainsKey(controls))
        {
            List<InputComponent> newList = new List<InputComponent>();
            newList.Add(inputComponent);
            InputManager.Instance.inputComponents.Add(controls, newList);
            //Debug.Log("One InputComponent added, Total=" + inputComponents.Count + "  " + controls);
        }
        else
        {
            InputManager.Instance.inputComponents[controls].Add(inputComponent);
        }

    }
    public void AddPlayerListener(ControllerPlayer controller)
    {
        RegisterInputComponent(controller.GetInputComponent(), controller.GetControls());
        controller.OnPlayerDeath += RemoveInputComponent;
    }
    public void ResetInput()
    {
        InputManager.Instance.playerInput = new Dictionary<Controls, Queue<InputData>>();
        InputManager.Instance.inputComponents = new Dictionary<Controls, List<InputComponent>>();
    }
    public void RemoveInputComponent(ControllerPlayer controller, InputComponent inputComponent, Controls controls)
    {
        //Debug.Log("One InputComponent Removed" + controls);
        InputManager.Instance.inputComponents[controls].Remove(inputComponent);


        if (InputManager.Instance.inputComponents.ContainsKey(controls) && InputManager.Instance.inputComponents[controls].Count == 0)
        {
            InputManager.Instance.inputComponents.Remove(controls);
            //InputManager.Instance.playerInput.Remove(controls);
            // ServiceUI.Instance.GameOver();
        }


    }
}
