using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class ControlsObject : MonoBehaviour
{
    [SerializeField] ControlMap controlMap;
    [SerializeField] int playerID; //1, 2, 3, or 4

    private ControlsPacket controls;
    private ControlsPacket prevControls;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        controls = new ControlsPacket(0, new Vector2(), new Vector2(), 0f, 0f);
        prevControls = controls;
    }

    // Update is called once per frame
    void Update()
    {
        prevControls = controls;

        DoControls();
    }

    private void DoControls()
    {
        Controls controlsRaw = 0;
        Vector2 lstick;
        Vector2 rstick;
        float l2;
        float r2;

        foreach (Controls control in System.Enum.GetValues(typeof(Controls)))
        {
            controlsRaw |= Input.GetKey(controlMap[control.ToString()]) ? control : 0;
        }

        if(controlMap.OnKeyboard)
        {
            float lsh = 0;
            if((controlsRaw & Controls.Right) == Controls.Right)
            {
                lsh++;
            }
            if((controlsRaw & Controls.Left) == Controls.Left)
            {
                lsh--;
            }

            float lsv = 0;
            if((controlsRaw & Controls.Up) == Controls.Up)
            {
                lsv++;
            }
            if((controlsRaw & Controls.Down) == Controls.Down)
            {
                lsv--;
            }

            lstick = new Vector2(lsh, lsv);

            float rsh = 0;
            if((controlsRaw & Controls.CRight) == Controls.CRight)
            {
                rsh++;
            }
            if ((controlsRaw & Controls.CLeft) == Controls.CLeft)
            {
                rsh--;
            }

            float rsv = 0;
            if ((controlsRaw & Controls.CUp) == Controls.CUp)
            {
                rsv++;
            }
            if ((controlsRaw & Controls.CDown) == Controls.CDown)
            {
                rsv--;
            }

            rstick = new Vector2(rsh, rsv);

            l2 = (controlsRaw & Controls.Shield) == Controls.Shield ? 1f : 0f;
            r2 = (controlsRaw & Controls.Shield) == Controls.Shield ? 1f : 0f;
        }
        else
        {
            lstick = new Vector2(Input.GetAxis("P" + playerID + " LSH"), Input.GetAxis("P" + playerID + " LSV"));
            rstick = new Vector2(Input.GetAxis("P" + playerID + " RSH"), Input.GetAxis("P" + playerID + " RSV"));
            l2 = Input.GetAxis("P" + playerID + " L2");
            r2 = Input.GetAxis("P" + playerID + " R2");

            double langle = Utils.Force360(Utils.ToDeg(Utils.VectorAngle(lstick)));
            if(langle <= controlMap.BaseHorizontalAngle || langle >= 360d - controlMap.BaseHorizontalAngle)
            {
                controlsRaw |= Controls.Right;
            }
            else if(langle >= 180d - controlMap.BaseHorizontalAngle && langle <= 180d + controlMap.BaseHorizontalAngle)
            {
                controlsRaw |= Controls.Left;
            }
            else if(langle < 180d)
            {
                controlsRaw |= Controls.Up;
            }
            else if(langle > 180d)
            {
                controlsRaw |= Controls.Down;
            }

            double rangle = Utils.Force360(Utils.ToDeg(Utils.VectorAngle(rstick)));
            if (rangle <= controlMap.BaseHorizontalAngleC || rangle >= 360d - controlMap.BaseHorizontalAngleC)
            {
                controlsRaw |= Controls.CRight;
            }
            else if (rangle >= 180d - controlMap.BaseHorizontalAngleC && rangle <= 180d + controlMap.BaseHorizontalAngleC)
            {
                controlsRaw |= Controls.CLeft;
            }
            else if (rangle < 180d)
            {
                controlsRaw |= Controls.CUp;
            }
            else if (rangle > 180d)
            {
                controlsRaw |= Controls.CDown;
            }

            if(l2 > 0 || r2 > 0)
            {
                controlsRaw |= Controls.Shield;
            }
        }

        controls = new ControlsPacket(controlsRaw, lstick, rstick, l2, r2);
    }

    public bool IsHeld(Controls controls)
    {
        return this.controls[controls];
    }

    public bool IsPressed(Controls controls)
    {
        return this.controls[controls] && !this.prevControls[controls];
    }

    public bool IsReleased(Controls controls)
    {
        return !this.controls[controls] && this.prevControls[controls];
    }

    public int PlayerID => playerID;
}

public struct ControlsPacket
{
    private Controls controls;
    private Vector2 lstick;
    private Vector2 rstick;
    private float l2;
    private float r2;

    public ControlsPacket(Controls controls, Vector2 lstick, Vector2 rstick, float l2, float r2)
    {
        this.controls = controls;
        this.lstick = lstick;
        this.rstick = rstick;
        this.l2 = l2;
        this.r2 = r2;
    }

    public bool this[Controls controls] => (this.controls & controls) == controls;
    public Controls Raw => controls;
    public Vector2 LStick => lstick;
    public Vector2 RStick => rstick;
    public float L2 => l2;
    public float R2 => r2;
}

public enum Controls : uint
{
    Up      = 0b_0000_0000_0000_0000_0001,
    Down    = 0b_0000_0000_0000_0000_0010,
    Left    = 0b_0000_0000_0000_0000_0100,
    Right   = 0b_0000_0000_0000_0000_1000,
    Attack  = 0b_0000_0000_0000_0001_0000,
    Special = 0b_0000_0000_0000_0010_0000,
    Grab    = 0b_0000_0000_0000_0100_0000,
    Shield  = 0b_0000_0000_0000_1000_0000,
    Dash    = 0b_0000_0000_0001_0000_0000,
    CUp     = 0b_0000_0000_0010_0000_0000,
    CDown   = 0b_0000_0000_0100_0000_0000,
    CLeft   = 0b_0000_0000_1000_0000_0000,
    CRight  = 0b_0000_0001_0000_0000_0000,
    Start   = 0b_0000_0010_0000_0000_0000,
    Taunt1  = 0b_0000_0100_0000_0000_0000,
    Taunt2  = 0b_0000_1000_0000_0000_0000,
    Taunt3  = 0b_0001_0000_0000_0000_0000,
    Taunt4  = 0b_0010_0000_0000_0000_0000,
    Jump    = 0b_0100_0000_0000_0000_0000
}

[CreateAssetMenu(menuName = "Controls Map")]
public class ControlMap : ScriptableObject
{
    [SerializeField] bool onKeyboard = true;

    [SerializeField] string up = "up";
    [SerializeField] string down = "down";
    [SerializeField] string left = "left";
    [SerializeField] string right = "right";
    [SerializeField] string attack = "x";
    [SerializeField] string special = "c";
    [SerializeField] string grab = "z";
    [SerializeField] string shield = "left shift";
    [SerializeField] string dash = "v";
    [SerializeField] string cup = "w";
    [SerializeField] string cdown = "s";
    [SerializeField] string cleft = "a";
    [SerializeField] string cright = "d";
    [SerializeField] string start = "return";
    [SerializeField] string taunt1 = "1";
    [SerializeField] string taunt2 = "2";
    [SerializeField] string taunt3 = "3";
    [SerializeField] string taunt4 = "4";
    [SerializeField] string jump = "space";

    [SerializeField] double baseHorizontalAngle = 30d;
    [SerializeField] double baseHorizontalAngleC = 45d;

    public string this[string propertyName] => GetType().GetProperty(propertyName).GetValue(this) as string;

    public bool OnKeyboard => onKeyboard;

    //returns the base horizontal angle in degrees using base wall angle logic
    public double BaseHorizontalAngle => baseHorizontalAngle;

    //same stuff but for c stick
    public double BaseHorizontalAngleC => baseHorizontalAngleC;

    public string Up => up;
    public string Down => down;
    public string Left => left;
    public string Right => right;
    public string Attack => attack;
    public string Special => special;
    public string Grab => grab;
    public string Shield => shield;
    public string Dash => dash;
    public string CUp => cup;
    public string CDown => cdown;
    public string CLeft => cleft;
    public string CRight => cright;
    public string Start => start;
    public string Taunt1 => taunt1;
    public string Taunt2 => taunt2;
    public string Taunt3 => taunt3;
    public string Taunt4 => taunt4;
    public string Jump => jump;
}
