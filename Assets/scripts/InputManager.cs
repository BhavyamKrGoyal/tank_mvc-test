using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GameElement
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
     if(Input.GetAxis("Horizontal1")!=0 || Input.GetAxis("Vertical1") != 0)
        {
      
            app.playerController.moveTank(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));
        }
        else
        {

        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            app.playerController.boosting();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            app.playerController.stopboosting();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            app.playerController.shooting();
        }

    }
}
