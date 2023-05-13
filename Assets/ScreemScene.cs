using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class ScreemScene : MonoBehaviour
{
    [SerializeField] private List<Lights> lightsCollection = new List<Lights>();
    
    [SerializeField] UnityEvent eventsAfterLight;

    [SerializeField] private GameObject firstPart;
    [SerializeField] private GameObject secondPart;

    [SerializeField] List<ParticleSystem> particles = new List<ParticleSystem>();
    [SerializeField] private Material blueMaterial;
    
    public void StartShow()
    {
        StartCoroutine(LightCoroutine());
    }

    public IEnumerator LightCoroutine()
    {
        foreach (var lightPair in lightsCollection)
        {
            yield return new WaitForSeconds(lightPair.delay);
            foreach (var lightObject in lightPair.lights)
            {
                lightObject.SetActive(true);
            }
        }
        eventsAfterLight.Invoke();
    }

    [Serializable]
    public class Lights
    {
        public GameObject[] lights;
        public float delay;
    }

    [Button("Move")]
    public void MoveFloor()
    {
        firstPart.transform.DOPunchPosition(Vector3.left * 10,5,0,1);
        secondPart.transform.DOPunchPosition(Vector3.right * 10,5,0,1);
    }

    public void RecolorAmbient()
    {
        
    }
}
