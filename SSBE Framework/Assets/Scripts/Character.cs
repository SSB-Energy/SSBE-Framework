using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Character : Entity
{
    [SerializeField] CharacterState state = CharacterState.Fall;
    [SerializeField] CharacterStateScriptList scriptList;

    protected int stateFrame = 0;
    protected CharacterStateScript currentStateScript;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        //reflective state scripts. Think "this.self" from SSF2
        currentStateScript = (CharacterStateScript)Activator.CreateInstance(Type.GetType(scriptList[state.ToString()]), new System.Object[] { this });
    }

    // Update is called once per frame
    void Update()
    {
        currentStateScript.DoFrame(stateFrame);
        stateFrame++;
    }

    public override void Land(Hitbox mine, Hitbox other)
    {
        SetState(CharacterState.Land);
    }

    public void SetState(CharacterState state)
    {
        this.state = state;
        stateFrame = 0;
        currentStateScript = (CharacterStateScript)Activator.CreateInstance(Type.GetType(scriptList[state.ToString()]), new System.Object[] { this });
    }
}

public enum CharacterState
{
    Fall,
    Land
}