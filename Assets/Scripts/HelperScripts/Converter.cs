using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Converter
{
    public static KeyCode StringToKeyCode(string str)
    {
        return (KeyCode) Enum.Parse(typeof(KeyCode), str);
    }
}
