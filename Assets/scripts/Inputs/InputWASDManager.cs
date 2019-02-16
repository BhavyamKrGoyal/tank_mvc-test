using UnityEngine;
using UnityEditor;
using Replay_Service;
using System.Collections.Generic;

public class InputWASDManager : MonoBehaviour
{
    InputData inputData;
    Controls controls = Controls.WASD;
    private void Start()
    {
        InputManager.Instance.playerInput.Add(controls,new Queue<InputData>());

    }
    public void Update()
    {
        if (InputManager.Instance.playerInput.ContainsKey(controls))
        {
            inputData = new InputData();
            inputData.forward = Input.GetAxis("Horizontal1");
            inputData.direction = Input.GetAxis("Vertical1");
            //Debug.Log("getting Input using IJKL");

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                inputData.boost = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                inputData.boost = false;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                inputData.shoot = true;
            }
            else
            {
                inputData.shoot = false;
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                PlayerPrefs.DeleteAll();
            }
            inputData.frame=FrameService.Instance.GetFrame();
        }
        InputManager.Instance.EnqueueData(inputData, controls);
        ServiceReplay.Instance.RecordInput(inputData, controls);
    }
}