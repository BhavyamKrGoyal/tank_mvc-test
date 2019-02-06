using UnityEngine;
using UnityEditor;

public class InputWASDManager : MonoBehaviour
{
    Controls controls = Controls.WASD;
    public void Update()
    {
        if (InputManager.Instance.playerInput.ContainsKey(controls)){
            InputManager.Instance.playerInput[controls].forward = Input.GetAxis("Horizontal1");
            InputManager.Instance.playerInput[controls].direction = Input.GetAxis("Vertical1");
            // Debug.Log("getting Input using WASD");

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
}