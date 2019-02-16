using System.Collections;
using System.Collections.Generic;
using Replay_Service;
using UnityEngine;

public class InputIJKLManager : MonoBehaviour
{
    Controls controls = Controls.IJKL;
    InputData inputData;
    private void Start() {
        InputManager.Instance.playerInput.Add(controls,new Queue<InputData>());
    
    }
    public void Update()
    {
        if (InputManager.Instance.playerInput.ContainsKey(controls))
        {
            inputData = new InputData();
            inputData.forward = Input.GetAxis("Horizontal");
            inputData.direction = Input.GetAxis("Vertical");
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
            inputData.frame=FrameService.Instance.GetFrame();
        }
        InputManager.Instance.EnqueueData(inputData,controls);
        ServiceReplay.Instance.RecordInput(inputData, controls);
    }
}
