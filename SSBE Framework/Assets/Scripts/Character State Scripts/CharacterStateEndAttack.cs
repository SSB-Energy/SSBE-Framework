using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateEndAttack : CharacterStateScript
{
    public CharacterStateEndAttack(Character self) : base(self)
    {
        
    }

    public override void DoFrame(uint frame)
    {
        switch(frame)
        {
            case 3:
                {
                    this.self.EndAttack();
                    return;
                }
        }
    }
}
