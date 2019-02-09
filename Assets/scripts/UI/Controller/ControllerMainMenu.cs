using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine.SceneManagement;

public class ControllerMainMenu
{
    ViewMainMenu view;
  
    public ControllerMainMenu()
    {

        view = GameObject.FindObjectOfType<ViewMainMenu>().GetComponent<ViewMainMenu>();
       // DisplayUI();
    
        
    }
    
     public void DestroyUI()
    {
        view.DestroyUI();
    }
    public void DisplayUI()
    {
        view.DisplayUI();
    }
    
}