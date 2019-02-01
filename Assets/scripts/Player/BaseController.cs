using UnityEngine;
using UnityEditor;
namespace Player
{
    public abstract class BasePlayerController
    {
        public virtual void UpdateScore(int score)
        {

        }
        public abstract bool IsFreez();
        public abstract void Move(float horizontal, float vertical);
        public abstract void DestroyObject();
        public abstract void Shoot();
        public virtual void StartBoost() { }
        public virtual void StopBoost() { }
    }
}