using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateScript 
{
    protected Character self;

    public CharacterStateScript(Character self)
    {
        this.self = self;
    }

    virtual public void DoFrame(uint frame)
    {

    }

    virtual public void OnLand()
    {
        this.self.SetState(CharacterState.Land);
    }
}
