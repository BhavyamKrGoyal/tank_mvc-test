using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputIJKLManager : MonoBehaviour
{
    Controls controls = Controls.IJKL;
    InputData inputData = new InputData();
    public void Update()
    {
        if (InputManager.Instance.playerInput.ContainsKey(controls))
        {
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
        }
        InputManager.Instance.playerInput[controls].Enqueue(inputData);
    }
}
