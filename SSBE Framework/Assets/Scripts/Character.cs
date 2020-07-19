using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Character : Entity
{
    [SerializeField] CharacterState state = CharacterState.Fall;
    [SerializeField] CharacterStateScriptList scriptList;
    [SerializeField] int playerID = 0;

    //Frame 1 == 0
    protected uint stateFrame = 0;
    protected CharacterStateScript currentStateScript;
    protected ControlsObject controls;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();

        controls = Utils.GetControlsObject(playerID);

        //reflective state scripts. Think "this.self" from SSF2
        currentStateScript = (CharacterStateScript)Activator.CreateInstance(Type.GetType(scriptList[state.ToString()]), new System.Object[] { this });
    }

    // Update is called once per frame
    void Update()
    {
        CharacterState prevState;
        do
        {
            prevState = state;
            currentStateScript.DoFrame(stateFrame);
        } while (prevState != state);
    }

    void LateUpdate()
    {
        stateFrame++;
    }

    public override void Land(Hitbox mine, Hitbox other)
    {
        currentStateScript.OnLand();
        
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
    Land,
    Idle
}