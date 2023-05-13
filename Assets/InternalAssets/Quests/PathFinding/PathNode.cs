using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class PathNode : MonoBehaviour
{
    public Vector2Int position;
    [SerializeField] private MeshRenderer meshRenderer;
    
    [OnValueChanged("ChangeColor")]
    [SerializeField] private NodeState state;

    public NodeState State
    {
        get { return state; }
        private set 
        {
            state = value;
            ChangeColor();
        }
    }

    public void SelectNode()
    {
        if (State != NodeState.Damaged)
        {
            State = NodeState.Selected;
        }
    }

    public void ActivateNode()
    {
        if (State != NodeState.Damaged)
        {
            State = NodeState.Active;
        }
    }

    public void UnselectNode()
    {
        if (State != NodeState.Damaged)
        {
            State = NodeState.Default;
        }
    }
    
    private void ChangeColor()
    {
        Color color;

        switch (state)
        {
            case NodeState.Active:
                color = Color.green;
                break;
            case NodeState.Damaged:
                color = Color.red;
                break;
            case NodeState.Default:
                color = Color.gray;
                break;
            case NodeState.Selected:
                color = Color.blue;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        meshRenderer.material.color = color;
    }
}

public enum NodeState
{
    Active,
    Damaged,
    Default,
    Selected
}