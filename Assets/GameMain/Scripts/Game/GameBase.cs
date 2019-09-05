
namespace ArrowPlay
{
    public abstract class GameBase
    {
        public bool IsGameOver = false;

        public virtual GameMode GameMode { get; }

        public virtual void Initialize()
        {
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        public virtual void OnLeave()
        {
        }
    }
}
