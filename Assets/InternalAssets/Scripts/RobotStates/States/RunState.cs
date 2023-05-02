using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "States/Robot/Run")]
public class RunState : State
{
    [SerializeField] private float runSpeed = 10f;
    public override void Init()
    {
        character.animator.SetBool("Roll_Anim",true);
        character.agent.speed = runSpeed;
        character.agent.isStopped = false;
    }

    public override void RunUpdate()
    {
        character.agent.SetDestination(character.player.position);
    }

    public override void UnInit()
    {
        character.animator.SetBool("Roll_Anim",false);
    }
}
