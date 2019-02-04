using UnityEngine;
using UnityEditor;
namespace Interfaces
{
    public interface IBasePlayerController
    {
        void UpdateScore(int score);
        Controls GetControls();
        bool IsFreez();
        void Move(float horizontal, float vertical);
        void DestroyObject();
        void Shoot();
        void StartBoost();
        void StopBoost();
    }
}