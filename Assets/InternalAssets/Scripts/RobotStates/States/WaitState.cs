using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "States/Robot/Wait")]
public class WaitState : State
{
    public override void Init()
    {
        character.agent.isStopped = true;
    }

    public override void RunUpdate()
    {
        
    }

    public override void UnInit()
    {
        
    }
}
