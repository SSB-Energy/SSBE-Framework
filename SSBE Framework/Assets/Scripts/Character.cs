﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    [SerializeField] CharacterState state = CharacterState.Fall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum CharacterState
{
    Fall
}