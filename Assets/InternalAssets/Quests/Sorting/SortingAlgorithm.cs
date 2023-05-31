using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Laboratory;
using NaughtyAttributes;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class SortingAlgorithm : MonoBehaviour
{
    [SerializeField] private List<SortPlatform> sortPlatforms;

    [SerializeField] private Transform reservePoint;

    public Queue<SortingQueueItem> sortingQueue = new Queue<SortingQueueItem>();
    public List<SortPlatform> Platforms => sortPlatforms;
    [SerializeField] private bool invertMove = false;
    private bool animIsEnded = true;
    
    private void Update()
    {
        if (animIsEnded
            && sortingQueue.Count > 0)
        {
            var item = sortingQueue.Dequeue();
            var movingObjectTransform = item.movingObject.transform;
            DOTween.Sequence()
                .AppendCallback(() => animIsEnded = false)
                .Append(movingObjectTransform.DOMoveX(movingObjectTransform.position.x - (invertMove?-4:4), 1))
                .Append(movingObjectTransform.DOMoveZ(item.newPosition.z, 1))
                .Append(movingObjectTransform.DOMoveX(movingObjectTransform.position.x, 1))
                .AppendCallback(() => animIsEnded = true);
        }
    }
    private void MoveToPoint(SortPlatform platform, Vector3 targetPosition)
    {
        sortingQueue.Enqueue(new SortingQueueItem(platform,targetPosition));
    }
    
    public void ReplacePlatforms(List<SortPlatform> newOrder)
    {
        var listOfPlatforms = sortPlatforms;

        for (int i = 0; i < newOrder.Count; i++)
        {
            int index = newOrder.IndexOf(listOfPlatforms[i]);
            
            if(index == i) continue;
            
            Vector3 iPos = listOfPlatforms[i].transform.position;
            Vector3 indexPos = listOfPlatforms[index].transform.position;
                
            var temp = listOfPlatforms[i];
            MoveToPoint(listOfPlatforms[i],reservePoint.position);

            listOfPlatforms[i] = listOfPlatforms[index];
            MoveToPoint(listOfPlatforms[index],iPos);

            listOfPlatforms[index] = temp;
            MoveToPoint(temp,indexPos);
        }
    }
}

public class SortingQueueItem
{
    public Vector3 newPosition;
    public SortPlatform movingObject;

    public SortingQueueItem(SortPlatform movingObject,Vector3 newPosition)
    {
        this.newPosition = newPosition;
        this.movingObject = movingObject;
    }
}