using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

#if UNITY_EDITOR
public class CustomSnapPoint : MonoBehaviour
{
    [SerializeField] private float radius = 0.4f;

    private void OnDrawGizmos()
    {
        if (CustomSnappingTool.IsActive)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position,radius);
        }
    }
}
#endif
