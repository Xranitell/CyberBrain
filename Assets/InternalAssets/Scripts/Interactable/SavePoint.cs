using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0,2,0);
    private TMP_Text _textInstance;

    private Collider collider;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        if (!_textInstance)
        {
            _textInstance =  GameObject.Find("SaveText").GetComponent<TMP_Text>();
        }

        collider = GetComponent<Collider>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveLoadSystem.SaveLastPosition(transform.position + offset);
            collider.enabled = false;
            _particleSystem.Stop();
            
            DOTween.Sequence()
                .Append(_textInstance.DOFade(1, 1))
                .AppendInterval(0.5f)
                .Append(_textInstance.DOFade(0, 1));
        }
    }
}
