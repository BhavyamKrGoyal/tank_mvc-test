using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    controller c;
    // Start is called before the first frame update
    void Start()
    {
        c = new controller(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerView>(), new TankModel());

    }
    // Update is called once per frame
    void Update()
    {
     if(Input.GetAxis("Horizontal1")!=0 || Input.GetAxis("Vertical1") != 0)
        {
      
            c.moveTank(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));
        }
        else
        {

        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            c.boosting();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            c.stopboosting();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            c.shooting();
        }

    }
}
