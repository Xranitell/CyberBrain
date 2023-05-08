using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Laboratory
{
    public class PathFinding : MonoBehaviour
    {
        [SerializeField] List<PathNode> Nodes = new List<PathNode>();
        [SerializeField] private TMP_Text energyAmount;

        [SerializeField] private Vector2Int startNode = new Vector2Int(0,0);
        [SerializeField] private Vector2Int endNode = new Vector2Int(4,4);
        
        public int maxEnergy;
        public int currentEnergy;

        [SerializeField] private GameObject trail;

        [SerializeField] UnityEvent onQuestComplete;
        [SerializeField] UnityEvent onQuestFailure;

        private static PathFinding Instance;
        private TrailRenderer _trailrenderer;
        private void Awake()
        {
            _trailrenderer = trail.GetComponentInChildren<TrailRenderer>();
            currentEnergy = maxEnergy;
            Instance = this;
            UpdateText();
        }

        private void ResetAllNodes()
        {
            foreach (var node in nodesGrid)
            {
                if (node.State == NodeState.Active)
                {
                    node.SelectNode();
                }
            }
        }
        
        private void UpdateText()
        {
            energyAmount.text = currentEnergy + "/" + maxEnergy;
        }

        public static PathNode[,] nodesGrid
        {
            get
            {
                PathNode[,] grid = new PathNode[5,5]; 
                
                for (int i = 0; i < Instance.Nodes.Count; i++)
                {
                    Instance.Nodes[i].Position = new Vector2Int(i / 5, i % 5);
                    
                    var pos = Instance.Nodes[i].Position;
                    
                    grid[pos.x,pos.y] = Instance.Nodes[i];
                }

                return grid;
            }
        }


        private Coroutine CheckCoroutineInst;
        public void CheckPathCorrect()
        {
            if(CheckCoroutineInst != null) StopCoroutine(CheckCoroutineInst);
            ResetAllNodes();
            DOTween.KillAll();
            CheckCoroutineInst = StartCoroutine(CheckCoroutine());
        }

        private IEnumerator CheckCoroutine()
        {
            currentEnergy = maxEnergy;
            
            PathNode currentNode = nodesGrid[startNode.x,startNode.y];
            
            _trailrenderer.time = 0.01f;
            yield return new WaitForSeconds(0.02f);
            trail.transform.position = currentNode.transform.position;
            _trailrenderer.time = 5f;
            
            currentNode.ActivateNode();
            do
            {
                currentNode = GetNodeBefore(currentNode);
                if (currentNode == null)
                {
                    onQuestFailure?.Invoke();
                }
                else
                {
                    currentEnergy--;
                    UpdateText();
                    currentNode.ActivateNode();
                    trail.transform.DOMove(currentNode.transform.position, 0.5f);
                    yield return new WaitForSeconds(0.5f);
                }

                if (currentNode == nodesGrid[endNode.x, endNode.y])
                {
                    onQuestComplete?.Invoke();
                    break;
                }
                
            } 
            while (currentNode != nodesGrid[endNode.x, endNode.y] && currentEnergy > 0);
            
        }

        private PathNode GetNodeBefore(PathNode currentNode)
        {
            var curPos = currentNode.Position;

            var offsets = new List<Vector2Int>()
            {
                { Vector2Int.right }, 
                { Vector2Int.left }, 
                { Vector2Int.up }, 
                { Vector2Int.down }
            };

            foreach (var offset in offsets)
            {
                Vector2Int newCell = curPos + offset;
                try
                {
                    if (nodesGrid[newCell.x,newCell.y].State == NodeState.Selected) 
                        return nodesGrid[newCell.x,newCell.y];
                }
                catch (Exception e)
                {
                    
                }
            }
            return null;
        }
    }
}
