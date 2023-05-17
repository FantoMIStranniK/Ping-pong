using SFML.Graphics;

namespace Ping_pong
{
    public interface ICollider
    {
        public bool IsCollidingWith(Shape thisShape, Shape collidedShape)
        {
            var thisBounds = thisShape.GetGlobalBounds();
            var collidedShapeBounds = collidedShape.GetGlobalBounds();

            if(thisBounds.Intersects(collidedShapeBounds))
                return true;

            return false;
        }
    }
}
