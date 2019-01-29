using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPlayer : MonoBehaviour
{
    Rigidbody rb;
    bool shoot = true;
    public GameObject muzzle;
    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();   
    }

    public IEnumerator Move(float h,float v)
    {
        Debug.Log(h);
        transform.Translate(0,0,v);
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, v);
        this.transform.Rotate(0, h, 0);
        yield return new WaitForEndOfFrame();
    }
    public void moveTank(float h,float v)
    {
        Debug.Log("view");
        StartCoroutine(Move(h,v));
    }
    IEnumerator Shoot(float time)
    {
        shoot = false;
        yield return new WaitForSeconds(time);
        shoot = true;
    }

}
