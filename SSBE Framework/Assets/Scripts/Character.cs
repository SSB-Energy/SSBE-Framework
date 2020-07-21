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
    [SerializeField] CharacterStats stats;

    //Frame 1 == 0
    protected uint stateFrame = 0;
    [SerializeField] bool grounded = false;
    [SerializeField] bool facingright = true;
    protected CharacterStateScript currentStateScript;
    protected ControlsObject controls;
    protected HitboxOwner lastplat = null;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();

        physics.sharedMaterial.friction = stats.Friction;
        physics.gravityScale = stats.Gravity;

        controls = Utils.GetControlsObject(playerID);

        //reflective state scripts. Think "this.self" from SSF2
        currentStateScript = (CharacterStateScript)Activator.CreateInstance(Type.GetType(scriptList[state.ToString()]), new System.Object[] { this });
    }

    // Update is called once per frame
    void Update()
    {
        if (true) //If not in hitlag and not grabbed
        {
            if (false) //if in knockback
            {
                //do knockback deceleration
            }

            //check if character has left ground

            if (false) //if glueToGround
            {
                //put character on platform
            }
        }
        else if (false) //else if in hitlag
        {
            if (false) //if at the end of hitlag
            {
                //do DI
            }

            //do SDI
        }

        //ProcessPassiveStateChange();

        if (Actionable)  //if actionable
        {
            //ProcessMovementStateChange();
        }

        if (!Actionable) //if not actionable
        {
            controls.UpdateBuffer();    //Update controls buffer
        }

        if (false) //if not in hitstun, hitlag, or any other immobilizing hting
        {
            //DoAirDrift();

            //ProcessAttackStateChange();
        }

        if (true) //if not in hitlag
        {
            //running the state script
            CharacterState prevState;
            uint prevStateFrame;
            do
            {
                prevState = state;
                prevStateFrame = stateFrame;
                currentStateScript.DoFrame(stateFrame);
            } while (prevState != state || prevStateFrame != stateFrame);
        }
    }

    void LateUpdate()
    {
        if (Actionable)  //If actionable
        {
            controls.ResetBuffer(); //reset buffer
        }

        if (false)   //if in hitlag
        {
            //Tick Hitlag Timer
        }
        else
        {
            if (false)   //if in hitstun
            {
                //Tick Hitstun Timer
            }

            //Tick Refresh Attack Boxes

            stateFrame++;
        }
    }

    /* Actionable states:
     * 
     * Fall
     * Idle
     * Walk
     * 
     */
    public bool Actionable
    {
        get
        {
            switch(state)
            {
                case CharacterState.Fall: return true;
                case CharacterState.Idle: return true;
                case CharacterState.Walk: return true;
            }

            return false;
        }
    }

    public bool Grounded
    {
        get
        {
            return grounded;
        }
        set
        {
            grounded = value;
        }
    }

    public void SetVel(Vector2 vel)
    {
        if(lastplat.GetComponent<Rigidbody2D>() != null)
        {
            physics.velocity = lastplat.GetComponent<Rigidbody2D>().velocity + vel;
        }
        else
        {
            physics.velocity = vel;
        }
    }

    public uint StateFrame
    {
        get
        {
            return stateFrame;
        }

        set
        {
            stateFrame = value;
        }
    }

    public override void Land(Hitbox mine, Hitbox other)
    {
        grounded = true;
        lastplat = other.Owner;
        currentStateScript.OnLand();
    }

    public void SetState(CharacterState state)
    {
        this.state = state;
        stateFrame = 0;
        currentStateScript = (CharacterStateScript)Activator.CreateInstance(Type.GetType(scriptList[state.ToString()]), new System.Object[] { this });
    }

    public void EndAttack()
    {
        if(state == CharacterState.Dash || state == CharacterState.Runturn)
        {
            if(facingright && controls.LStick.x > 0 || !facingright && controls.LStick.x < 0)
            {
                SetState(CharacterState.Run);
            }
            else
            {
                SetState(CharacterState.Skid);
            }
        }
        else if(state == CharacterState.Jumpcrouch)
        {
            //DoJump
        }
        else if(state == CharacterState.Pummel)
        {
            SetState(CharacterState.Hold);
        }
        else if(Grounded)
        {
            SetState(CharacterState.Idle);
        }
        else
        {
            SetState(CharacterState.Fall);
        }
    }
}

public enum CharacterState
{
    Fall,   //implemented
    Land,   //implemented
    Idle,   //implemented
    Walk,   //implemented
    Dash,
    Run,
    Skid,
    Runturn,
    Crouch,
    Jumpcrouch,
    Rise,
    Peak,
    Doublejump,
    Shield,
    Shieldrelease,
    Dizzy,
    Tumble,
    Airdodge,
    Roll,
    Freefall,
    Spotdodge,
    Jab,
    Ftilt,
    Utilt,
    Dtilt,
    Fsmash,
    Usmash,
    Dsmash,
    Grab,
    Pummel,
    Fthrow,
    Uthrow,
    Bthrow,
    Dthrow,
    Nair,
    Fair,
    Uair,
    Bair,
    Dair,
    Nspecg,
    Sspecg,
    Uspecg,
    Dspecg,
    Nspeca,
    Sspeca,
    Uspeca,
    Dspeca,
    Dashatk,
    Hold,
    Hurt,
    Launched,
    Grabbed,
    Ledgehang,
    Ledgeclimb,
    Ledgeatk,
    Ledgeroll,
    Ledgejumpcrouch,
    Crash,
    Crashgetup,
    Crashroll,
    Crashatk,
    Tech,
    Techroll
}