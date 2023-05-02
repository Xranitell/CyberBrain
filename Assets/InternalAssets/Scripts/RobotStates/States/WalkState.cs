using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "States/Robot/Walk")]
public class WalkState : State
{
    [SerializeField] private float walkSpeed = 5f;
    public override void Init()
    {
        character.animator.SetBool("Walk_Anim",true);
        character.agent.speed = walkSpeed;
        character.agent.isStopped = false;
    }

    public override void RunUpdate()
    {
        character.agent.SetDestination(character.player.position);
    }

    public override void UnInit()
    {
        character.animator.SetBool("Walk_Anim",false);
    }
}
