using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class p much only exists to streamline hitbox interactions
public class HitboxOwner : MonoBehaviour
{
    //Called whenever a hitbox interacts with another.
    public void CollisionEvent(Hitbox mine, Hitbox other)
    {
        /* Interactions Chart
         * Each row represents a "mine" hitbox
         * Each column represents an "other" hitbox
         * 
         * 
         * \   C S A H G
         * 
         * C   X O X X X
         * S   O X X X X
         * A   X X X O X
         * H   X X O X O
         * G   X X X O X
         * 
         */

        switch (mine.Type)
        {
            case HitboxType.Collision:
                {
                    if (other.Type == HitboxType.Solid)
                    {
                        CollisionOnSolid(mine, other);
                    }
                    break;
                }
            case HitboxType.Solid:
                {
                    if (other.Type == HitboxType.Collision)
                    {
                        SolidOnCollision(mine, other);
                    }
                    break;
                }
            case HitboxType.Attack:
                {
                    if (other.Type == HitboxType.Hurt)
                    {
                        AttackOnHurt(mine, other);
                    }
                    break;
                }
            case HitboxType.Hurt:
                {
                    if (other.Type == HitboxType.Attack)
                    {
                        HurtOnAttack(mine, other);
                    }
                    else if(other.Type == HitboxType.Grab)
                    {
                        HurtOnGrab(mine, other);
                    }
                    break;
                }
            case HitboxType.Grab:
                {
                    if(other.Type == HitboxType.Hurt)
                    {
                        GrabOnHurt(mine, other);
                    }
                    break;
                }
        }
    }

    virtual public void CollisionOnSolid(Hitbox mine, Hitbox other)
    {

    }

    virtual public void SolidOnCollision(Hitbox mine, Hitbox other)
    {

    }

    virtual public void AttackOnHurt(Hitbox mine, Hitbox other)
    {

    }

    virtual public void HurtOnAttack(Hitbox mine, Hitbox other)
    {

    }

    virtual public void HurtOnGrab(Hitbox mine, Hitbox other)
    {

    }

    virtual public void GrabOnHurt(Hitbox mine, Hitbox other)
    {

    }
}
