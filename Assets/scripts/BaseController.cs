using UnityEngine;
using UnityEditor;

public abstract class BaseController 
{
    public abstract bool CheckFreez();
    public abstract void Move(float horizontal, float vertical);
    public abstract void DestroyObject();
    public abstract void Shoot();
    public virtual void StartBoost() { }
    public virtual void StopBoost() { }
}