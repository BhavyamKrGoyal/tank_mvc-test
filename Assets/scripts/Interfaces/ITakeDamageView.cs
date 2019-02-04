using UnityEngine;
using UnityEditor;

namespace Interfaces
{
    public interface ITakeDamageView
    {
        void TakeDamage(int damage,IBasePlayerController player);
        
    }
}