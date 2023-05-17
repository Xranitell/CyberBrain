using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    public TypePatrol type;
    public float speed = 2f;
    public float waitTime = 1;
    
    private int targetPointID = 1;
    private int currentPointID = 0;

    private bool isMoving = true;

    private void Start()
    {
        transform.position = points[0].position;
    }

    int GetNextPoint(int currentPointID)
    {
        if (type == TypePatrol.Circle)
        {
            if (currentPointID == points.Count-1)
            {
                return 0;
            }
            else
            {
                return ++currentPointID;
            }
        }
        else
        {
            if (currentPointID == points.Count - 1 || currentPointID == 0)
            {
                points.Reverse();
                currentPointID = 0;
                return 1;
            }
            else
            {
                return ++currentPointID;
            }
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(!isMoving) return;
        
        
        transform.position = Vector3.MoveTowards(transform.position, points[targetPointID].position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, points[targetPointID].position) <= 0.2f)
        {
            currentPointID = targetPointID;
            targetPointID = GetNextPoint(currentPointID);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isMoving = false;
        yield return new WaitForSeconds(waitTime);
        isMoving = true;
    }
}
public enum TypePatrol
{
    ForwardAndBack,
    Circle
}
