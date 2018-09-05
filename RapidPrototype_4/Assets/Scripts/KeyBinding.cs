using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinding : MonoBehaviour {

    [System.NonSerialized]
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    void Start()
    {
        ResetKeys();
    }

    public void ResetKeys()
    {
        keys.Add("Up1", KeyCode.W);
        keys.Add("Down1", KeyCode.S);
        keys.Add("Left1", KeyCode.A);
        keys.Add("Right1", KeyCode.D);
        keys.Add("Jump1", KeyCode.Space);
        keys.Add("Fire1", KeyCode.F);
        keys.Add("AltFire1", KeyCode.G);

        keys.Add("Up2", KeyCode.UpArrow);
        keys.Add("Down2", KeyCode.DownArrow);
        keys.Add("Left2", KeyCode.LeftArrow);
        keys.Add("Right2", KeyCode.RightArrow);
        keys.Add("Jump2", KeyCode.Keypad0);
        keys.Add("Fire2", KeyCode.KeypadPeriod);
        keys.Add("AltFire2", KeyCode.Keypad1);
    }
}
