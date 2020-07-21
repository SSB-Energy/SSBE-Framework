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

    //if frame == 0, it's frame 1
    /* This bit is based on a flaw in the design, but it can't be helped. A character can have 15 frames on 
     * an attack (frame == 0 to frame == 14), but then have a frame == 15 method at the very end. This means it'll 
     * run on the 16th frame of the attack. Stuff like that should usually only be used for jumping to a frame or
     * calling EndAttack(). Additionally, IASA is strongly encouraged to be active during this frame.
     * 
     * 
     * So, as an example of how stuff should be done, say a character has a 30 frame attack. This is how you'd write code for it.
     * 
     * switch(frame)
     * {
     *     case 0:
     *     {
     *         Frame1();
     *     }
     *     case 29:
     *     {
     *         Frame30();
     *         this.self.IASA = true;
     *     }
     *     case 30:
     *     {
     *         this.self.EndAttack();
     *     }
     * }
     */
    virtual public void DoFrame(uint frame)
    {

    }

    virtual public void OnLand()
    {
        this.self.SetState(CharacterState.Land);
    }

    virtual public void ButtonInput()
    {

    }
}
