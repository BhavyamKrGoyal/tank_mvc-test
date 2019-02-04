using UnityEngine;
using UnityEditor;
namespace Player
{
    public interface BasePlayerController
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