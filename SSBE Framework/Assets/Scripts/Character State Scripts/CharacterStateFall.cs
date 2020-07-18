using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Transactions;
using UnityEngine;

public class CharacterStateFall : CharacterStateScript
{
    public CharacterStateFall(Character self) : base(self)
    {
        MonoBehaviour.print(this.self.GetType() + ", " + GetType());
    }
}
