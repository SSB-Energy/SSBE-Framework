﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateLoopable : CharacterStateScript
{
    public CharacterStateLoopable(Character self) : base(self)
    {

    }

    public override void DoFrame(uint frame)
    {
        switch (frame)
        {
            case 3:
                {
                    this.self.StateFrame = 0;
                    return;
                }
        }
    }
}
