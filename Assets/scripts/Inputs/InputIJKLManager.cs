using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputIJKLManager : InputManager
{
    int playerNumber = 1;
    public override void Update()
    {

        playerInput[playerNumber].forward = Input.GetAxis("Horizontal");
        playerInput[playerNumber].direction = Input.GetAxis("Vertical");
        //Debug.Log("getting Input using IJKL");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerInput[playerNumber].boost = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerInput[playerNumber].boost = false;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            playerInput[playerNumber].shoot = true;
        }
        else
        {
            playerInput[playerNumber].shoot = false;
        }
        base.Update();
    }
}
