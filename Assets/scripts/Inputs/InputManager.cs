using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public  Dictionary<Controls, InputData> playerInput = new Dictionary<Controls, InputData>();
    public  Dictionary<Controls, List<InputComponent>> inputComponents = new Dictionary<Controls, List<InputComponent>>();


    // Start is called before the first frame update
    // Update is called once per frame
    public virtual void Update()
    {
        foreach (Controls controls in InputManager.Instance.inputComponents.Keys)
        {
            foreach(InputComponent inputComponent in inputComponents[controls])
            {
                Debug.Log(InputManager.Instance.playerInput[Controls.IJKL].forward);
              
                inputComponent.InputUpdate(InputManager.Instance.playerInput[controls].forward, InputManager.Instance.playerInput[controls].direction, InputManager.Instance.playerInput[controls].shoot, InputManager.Instance.playerInput[controls].boost);
            }
        }

    }
    public void RegisterInputComponent(InputComponent inputComponent, Controls controls)
    {

        if (!InputManager.Instance.playerInput.ContainsKey(controls))
        {
            InputManager.Instance.playerInput.Add(controls, new InputData());
            List<InputComponent> newList = new List<InputComponent>();
            newList.Add(inputComponent);
            InputManager.Instance.inputComponents.Add(controls, newList);
        }
        else
        {
            InputManager.Instance.inputComponents[controls].Add(inputComponent);
        }
         Debug.Log("One InputComponent added, Total="+inputComponents.Count +"  "+controls);
    }
    public void RemoveInputComponent(InputComponent inputComponent, Controls controls)
    {
        InputManager.Instance.inputComponents[controls].Remove(inputComponent);
        if(InputManager.Instance.inputComponents[Controls.WASD].Count==0 && InputManager.Instance.inputComponents[Controls.IJKL].Count == 0)
        {
            ServiceUI.Instance.GameOver();
        }
         Debug.Log("One InputComponent Removed, Total=" + inputComponents.Count);
    }
}
