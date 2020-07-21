using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Stats")]
public class CharacterStats : ScriptableObject
{
    [SerializeField] float gravity = 2f;
    [SerializeField] float walkspeed = 4f;
    [SerializeField] float friction = 0.4f;

    public float Gravity => gravity;
    public float WalkSpeed => walkspeed;
    public float Friction => friction;
}
