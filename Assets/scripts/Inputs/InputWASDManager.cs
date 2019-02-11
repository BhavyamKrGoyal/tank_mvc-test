using UnityEngine;
using UnityEditor;

public class InputWASDManager : MonoBehaviour
{
    InputData inputData=new InputData();
    Controls controls = Controls.WASD;
    public void Update()
    {
          if (InputManager.Instance.playerInput.ContainsKey(controls))
        {
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

        }
        InputManager.Instance.playerInput[controls].Enqueue(inputData);
    }
}