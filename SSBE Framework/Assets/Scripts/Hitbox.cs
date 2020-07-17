using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] HitboxType type = HitboxType.Collision;
    [SerializeField] Entity owner = null;

    
    private Collider2D collider2d;

    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();

        Hitbox[] hitboxes = FindObjectsOfType<Hitbox>();
        foreach(Hitbox hitbox in hitboxes)
        {
            if((type == hitbox.Type || owner == hitbox.Owner) && hitbox.Collider2D != null)
            {
                Physics2D.IgnoreCollision(collider2d, 
                    hitbox.Collider2D);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public HitboxType Type => type;
    public Entity Owner => owner;

    public Collider2D Collider2D => collider2d;
}

public enum HitboxType
{
    Collision,
    Solid
}