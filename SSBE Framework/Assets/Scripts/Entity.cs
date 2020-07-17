using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : HitboxOwner
{
    //States
    protected Rigidbody2D physics = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Okay, so this is a little bit of stuff to determine whether something's a land, ceiling, or wall interaction. See Utils for more details
    public override void CollisionOnSolid(Hitbox mine, Hitbox other)
    {
        ColliderDistance2D distance = mine.GetComponent<Collider2D>().Distance(other.GetComponent<Collider2D>());

        double angle = Utils.Force2PI(Utils.VectorAngle(distance.normal));

        if(angle > Utils.ToRad(Utils.WallBaseAngleDeg) && angle < Utils.ToRad(180d - Utils.WallBaseAngleDeg))
        {
            CeilBonk(mine, other);
        }
        else if(angle > Utils.ToRad(180d + Utils.WallBaseAngleDeg) && angle < Utils.ToRad(360d - Utils.WallBaseAngleDeg))
        {
            Land(mine, other);
        }
        else
        {
            WallBonk(mine, other);
        }
    }

    virtual public void Land(Hitbox mine, Hitbox other)
    {

    }

    virtual public void WallBonk(Hitbox mine, Hitbox other)
    {
        
    }

    virtual public void CeilBonk(Hitbox mine, Hitbox other)
    {
        
    }
}
