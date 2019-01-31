using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
     protected static List<InputData> playerInput=new List<InputData>();
     static List<InputComponent> inputComponents = new List<InputComponent>();
    
    // Start is called before the first frame update
    // Update is called once per frame
    public virtual void Update()
    {
        for (int i = 0; i < inputComponents.Count; i++)
        {
            inputComponents[i].InputUpdate(playerInput[i].forward, playerInput[i].direction, playerInput[i].shoot, playerInput[i].boost);
        }
    }
    public void RegisterInputComponent(InputComponent inputComponent)
    {
        inputComponents.Add(inputComponent);
        playerInput.Add(new InputData());
       // Debug.Log("One InputComponent added, Total="+inputComponents.Count);
    }
    public void RemoveInputComponent(InputComponent inputComponent)
    {
        inputComponents.Remove(inputComponent);
       // Debug.Log("One InputComponent Removed, Total=" + inputComponents.Count);
    }
}
