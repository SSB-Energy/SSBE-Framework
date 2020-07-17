using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IMPORTANT
//Anything that uses Hitbox as a component MUST also use an instance of Collider2D as a component and must have an instance of HitboxOwner as a parent
//THIS IS NON-NEGOTIABLE
public class Hitbox : MonoBehaviour
{
    [SerializeField] HitboxType type = HitboxType.Collision;


    private HitboxOwner owner;
    private Collider2D collider2d;

    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        owner = transform.parent.gameObject.GetComponent<HitboxOwner>();

        Hitbox[] hitboxes = FindObjectsOfType<Hitbox>();
        foreach(Hitbox hitbox in hitboxes)
        {
            if((type == hitbox.Type || owner == hitbox.Owner) && hitbox.Collider2D != null)
            {
                Physics2D.IgnoreCollision(collider2d, hitbox.Collider2D);
            }
        }
    }

    //See HitboxOwner
    private void OnCollisionEnter2D(Collision2D collision)
    {
        owner.CollisionEvent(this, collision.collider.GetComponent<Hitbox>());
    }

    //Type shows what type of hitbox it is
    public HitboxType Type => type;
    public HitboxOwner Owner => owner;

    public Collider2D Collider2D => collider2d;
}

public enum HitboxType
{
    Collision,
    Solid,
    Attack,
    Hurt,
    Grab
}