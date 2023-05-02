#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

[EditorTool("Custom Snap Move", typeof(CustomSnap))]
public class CustomSnappingTool : EditorTool
{
    //public override GUIContent toolbarIcon { get; }
    private Transform oldTarget;
    CustomSnapPoint[] allPoints;
    CustomSnapPoint[] targetPoints;

    public static bool IsActive;

    private void OnEnable()
    {
        IsActive = true;
    }

    private void OnDisable()
    {
        IsActive = false;
    }
    public override void OnToolGUI(EditorWindow window)
    {
        Transform targetTransform = ((CustomSnap)target).transform;

        if (targetTransform != oldTarget)
        {
            allPoints = FindObjectsOfType<CustomSnapPoint>();
            targetPoints = targetTransform.GetComponentsInChildren<CustomSnapPoint>();

            oldTarget = targetTransform;
        }
        
        EditorGUI.BeginChangeCheck();
        Vector3 newPos = Handles.PositionHandle(targetTransform.position, Quaternion.identity);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetTransform,"Move with snap tool");
            MoveWithSnapping(targetTransform,newPos);
        }
    }
    private void MoveWithSnapping(Transform targetTransform, Vector3 newPosition)
    {
        
        Vector3 bestPosition = newPosition;
        float closestDistance = float.PositiveInfinity;

        foreach (var customSnapPoint in allPoints)
        {
            if (customSnapPoint.transform.parent == targetTransform) continue;

            foreach (var ownPoint in targetPoints)
            {
                Vector3 targetPos = customSnapPoint.transform.position -
                                    (ownPoint.transform.position - targetTransform.position);
                float distance = Vector3.Distance(targetPos, newPosition);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    bestPosition = targetPos;
                }
            }
        }

        targetTransform.position = closestDistance < 0.7f ? bestPosition : newPosition;
    }
}
#endif
