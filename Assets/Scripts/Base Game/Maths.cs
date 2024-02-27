using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths : MonoBehaviour
{
    public static int CeilToInt(float value)
    {
        int intValue = (int)value;
        return value > intValue ? intValue + 1 : intValue;
    }

    public static int FloorToInt(float value)
    {
        int intValue = (int)value;
        return value < 0 ? (value - intValue < 0 ? intValue - 1 : intValue) : intValue;
    }

    public static int RoundToInt(float value)
    {
        int intValue = (int)value;
        float fractionalPart = value - intValue;
        if (fractionalPart >= 0.5f)
        {
            return intValue + 1;
        }
        else if (fractionalPart <= -0.5f)
        {
            return intValue - 1;
        }
        else
        {
            return intValue;
        }
    }


}
