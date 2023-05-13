using DG.Tweening;
using Laboratory;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Vector3 activeState;
    [SerializeField] Vector3 disabledState;

    [SerializeField] private float animationDuration = 1;

    public void Activate()
    {
        transform.DOMove(activeState,animationDuration);
    }

    public void Deactivate()
    {
        transform.DOMove(disabledState,animationDuration);
    }
}
