using UnityEngine;
using UnityEditor;

public class InputWASDManager : InputManager
{
    int playerNumber = 0;
    public override void Update()
    {

        playerInput[playerNumber].forward = Input.GetAxis("Horizontal1");
        playerInput[playerNumber].direction = Input.GetAxis("Vertical1");
       // Debug.Log("getting Input using WASD");

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