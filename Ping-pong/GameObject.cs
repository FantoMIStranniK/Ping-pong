
using SFML.Graphics;

namespace Ping_pong
{
    public abstract class GameObject : ICollider, IMovement
    {
        public string tag = " ";

        protected ICollider m_Collider;
        protected IMovement m_Movement;

        public Shape DrawableShape;

        public virtual void Move(){}
        public virtual void Awake(){}
        public virtual void Update(){}
        public virtual void Destroy(){}
    }
}
