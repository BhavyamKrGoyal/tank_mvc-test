using System.Collections;
using System.Collections.Generic;
using Replay_Service;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : Singleton<InputManager>
{

    public int initialFame;

    public Dictionary<Controls, Queue<InputData>> playerInput = new Dictionary<Controls, Queue<InputData>>();
    public GameObject InputControllersPrefab, referenceInput;
    public Dictionary<Controls, List<InputComponent>> inputComponents = new Dictionary<Controls, List<InputComponent>>();
    public bool userControls = true, replay = false;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {

        StateManager.Instance.OnStateChanged += GameStateChanged;

        GameApplication.Instance.OnPlayerSpawn += AddPlayerListener;
    }
    public void SetQueue(Dictionary<Controls, List<InputData>> Pinput)
    {
        foreach (Controls controls in Pinput.Keys)
        {
            for (int i = 0; i < Pinput[controls].Count; i++)
            {
                playerInput[controls].Enqueue(Pinput[controls][i]);
            }
        }
    }

    public void EnqueueData(InputData inputdata, Controls controls)
    {
        if (Instance.playerInput.ContainsKey(controls))
        {
            //ServiceReplay.Instance.RecordInput(inputdata, controls);
            Instance.playerInput[controls].Enqueue(inputdata);
        }
    }
    public virtual void Update()
    {
        foreach (Controls controls in InputManager.Instance.inputComponents.Keys)
        {
            foreach (InputComponent inputComponent in inputComponents[controls])
            {

                if (Instance.playerInput[controls].Count > 0)
                {

                    // Debug.Log((Time.frameCount - initialFame - 1) + "  " + Instance.playerInput[controls].Peek().frame);
                    if ((Time.frameCount - initialFame - 1) == Instance.playerInput[controls].Peek().frame)
                    {
                        //Debug.Log(InputManager.Instance.playerInput[Controls.IJKL].forward);
                        inputComponent.InputUpdate(Instance.playerInput[controls].Dequeue());
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
            if (userControls)
            {
                initialFame = Time.frameCount;
                referenceInput = Instantiate(InputControllersPrefab);
            }
        }
    }
    public void GameStateChanged(GameState currentState)
    {
        if (currentState is GamePlayState)
        {

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
            {
                replay = true;
                initialFame = Time.frameCount;

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
        }
        else
        {
            InputManager.Instance.inputComponents[controls].Add(inputComponent);
        }
        //Debug.Log("One InputComponent added, Total="+inputComponents.Count +"  "+controls);
    }
    public void AddPlayerListener(ControllerPlayer controller)
    {

        RegisterInputComponent(controller.GetInputComponent(), controller.GetControls());
        controller.OnPlayerDeath += RemoveInputComponent;

    }
    public void RemoveInputComponent(ControllerPlayer controller, InputComponent inputComponent, Controls controls)
    {
        InputManager.Instance.inputComponents[controls].Remove(inputComponent);

        // Debug.Log("One InputComponent Removed WASD, Total=" + inputComponents[controls].Count);
        if (InputManager.Instance.inputComponents.ContainsKey(controls) && InputManager.Instance.inputComponents[controls].Count == 0)
        {
            InputManager.Instance.inputComponents.Remove(controls);
            //InputManager.Instance.playerInput.Remove(controls);
            // ServiceUI.Instance.GameOver();
        }


    }
}
