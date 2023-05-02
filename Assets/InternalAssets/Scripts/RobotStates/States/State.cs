using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    public RobotController character;
    public abstract void Init();

    public abstract void RunUpdate();

    public abstract void UnInit();
}
