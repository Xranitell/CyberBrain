using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratory
{
    public class LaboratoryObjects : MonoBehaviour
    {
        public static PathFinding APathFinding {get; private set; }
        public static PathFinding BFSPathFinding;

        private void Awake()
        {
            APathFinding = GameObject.Find("APathFinding").GetComponent<PathFinding>();
            //BFSPathFinding = GameObject.Find("BFSPathFinding").GetComponent<PathFinding>();
        }

    }
}

