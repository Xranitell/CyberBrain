using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public NavMeshAgent agent;

    public static RobotController Instance;

    [SerializeField] private float walkDistance = 5;
    [SerializeField] private float waitDistance = 4;
    [SerializeField] private float teleportDistance = 20;
    [SerializeField] private Vector3 teleportOffset = new Vector3(-2,0,0);
    

    private State CurrentState;

    [SerializeField] private RunState runState;
    [SerializeField] private WalkState walkState;
    [SerializeField] private WaitState waitState;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        var dist = Vector3.Distance(player.position, transform.position);
        
        if (dist > walkDistance) //Дистанция состояния бега
        {
            SetState(runState);
        }
        else if (dist <= walkDistance && dist > waitDistance) //Дистанция ходьбы
        {
            SetState(walkState);
        }
        else if (dist < waitDistance)
        {
            SetState(waitState);
        }
        if (dist >= teleportDistance)
        {
            
        }
        
        CurrentState.RunUpdate();
    }

    public void TeleportToPlayer()
    {
        transform.position =  player.position + teleportOffset;
        agent.Warp(player.position + teleportOffset);
        agent.SetDestination(player.position);
    }
    
    public void SetState(State state)
    {
        CurrentState?.UnInit();
        
        CurrentState = Instantiate(state);
        CurrentState.character = this;
        
        CurrentState.Init();
    }

    public void StopMovement()
    {
        agent.isStopped = true;
        Debug.Log("Stop");
    }
    public void StartMovement()
    {
        agent.isStopped = false;
        Debug.Log("Start");
    }
}
