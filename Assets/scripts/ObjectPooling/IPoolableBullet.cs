using Interfaces;

namespace ObjectPooling
{
    public interface IPoolableBullet : IPoolable
    {
        void SetShooter(IBasePlayerController shooter);
    }
}