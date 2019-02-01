using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputIJKLManager : MonoBehaviour
{
    Controls controls = Controls.IJKL;
    public void Update()
    {

        InputManager.Instance.playerInput[controls].forward = Input.GetAxis("Horizontal");
        InputManager.Instance.playerInput[controls].direction = Input.GetAxis("Vertical");
        //Debug.Log("getting Input using IJKL");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            InputManager.Instance.playerInput[controls].boost = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            InputManager.Instance.playerInput[controls].boost = false;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            InputManager.Instance.playerInput[controls].shoot = true;
        }
        else
        {
            InputManager.Instance.playerInput[controls].shoot = false;
        }
    }
}
