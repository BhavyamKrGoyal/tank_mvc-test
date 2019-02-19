using UnityEngine;

namespace ObjectPooling
{
    public interface IPoolable
    {
         void Reset();
         void Set(Transform muzzle);
    }
}