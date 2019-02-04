using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewOverSceneUI : MonoBehaviour
{
    // Start is called before the first frame update
   

    public void Replay()
    {
        ServiceUI.Instance.Replay();

    }
    public void LoadMenu()
    {
        ServiceUI.Instance.LoadMenu();
    }
}
