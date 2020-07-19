using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Utils : MonoBehaviour
{
    //If an object is pushed away in the range of (WallBaseAngleDeg, -WallBaseAngleDeg) or (180 - WallBaseAngleDeg, 180 + WallBaseAngleDeg), it's considered a wall interaction
    public static double WallBaseAngleDeg = 30d;


    //returns the angle of a vector in radians
    public static double VectorAngle(Vector2 vector)
    {
        return Math.Atan2(vector.y, vector.x);
    }

    //returns the degree form of a radian value
    public static double ToDeg(double rad)
    {
        return rad * 180 / Math.PI;
    }

    //returns the radian form of a degree value
    public static double ToRad(double deg)
    {
        return deg * Math.PI / 180;
    }

    //constrains a degree value into the range (0, 360)
    public static double Force360(double deg)
    {
        deg %= 360;
        if(deg < 0)
        {
            deg += 360;
        }

        return deg;
    }

    //constrains a radian value into the range (0, 2PI)
    public static double Force2PI(double rad)
    {
        rad %= Math.PI * 2;
        if(rad < 0)
        {
            rad += Math.PI * 2;
        }

        return rad;
    }

    public static ControlsObject GetControlsObject(int playerID)
    {
        ControlsObject[] controlsObjects = FindObjectsOfType<ControlsObject>();
        foreach(ControlsObject controlsObject in controlsObjects)
        {
            if(playerID == controlsObject.PlayerID)
            {
                return controlsObject;
            }
        }

        return null;
    }
}
