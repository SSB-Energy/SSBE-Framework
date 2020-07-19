using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateLand : CharacterStateScript
{
    public CharacterStateLand(Character self) : base(self)
    {
        
    }

    public override void DoFrame(uint frame)
    {
        switch(frame)
        {
            case 3:
                {
                    this.self.SetState(CharacterState.Idle);

                    break;
                }
        }
    }
}
