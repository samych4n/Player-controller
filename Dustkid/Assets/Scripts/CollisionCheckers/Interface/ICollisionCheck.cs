using UnityEngine;
public interface ICollisionCheck
{
    bool IsInCollision { get; }
    bool IsReallyInCollision { get; }
    Vector2 Normal { get; }
    GameObject CurrentCollisionObject { get; }
    Collider2D CurrentCollisionCollider { get; }
}
