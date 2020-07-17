using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    [SerializeField] CharacterState state = CharacterState.Fall;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Land(Hitbox mine, Hitbox other)
    {
        state = CharacterState.Land;
    }
}

public enum CharacterState
{
    Fall,
    Land
}