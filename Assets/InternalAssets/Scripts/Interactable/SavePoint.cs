using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0,2,0);
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveLoadSystem.SaveLastPosition(transform.position + offset);
            this.gameObject.SetActive(false);
        }
    }
}
