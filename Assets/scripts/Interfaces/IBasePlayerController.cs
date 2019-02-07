using UnityEngine;
using UnityEditor;
namespace Interfaces
{
    public interface IBasePlayerController
    {
       
        Controls GetControls();
        bool IsFreez();
        void Update(float horizontal, float vertical);
        void DestroyObject();
        void Shoot();
        void StartBoost();
        void StopBoost();
    }
}