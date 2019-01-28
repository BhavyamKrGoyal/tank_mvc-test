using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    Rigidbody rb;
    bool shoot = true;
    public GameObject bullet,muzzle;
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
    public void Startshoot(float power,float interval)
    {
        if (shoot)
        {
            StartCoroutine(Shoot(interval));
            GameObject shell = Instantiate  (bullet, muzzle.transform.position,muzzle.transform.rotation, null);
            shell.GetComponent<Rigidbody>().velocity = transform.forward * power;
            Destroy(shell, 3);
        }
    }
    IEnumerator Shoot(float time)
    {
        shoot = false;
        yield return new WaitForSeconds(time);
        shoot = true;
    }

}
