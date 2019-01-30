using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetColour(Color color)
    {
        gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", color);
    }
}
