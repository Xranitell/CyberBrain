using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratory
{
    public class LaboratoryObjects : MonoBehaviour
    {
        public static PathFinding APathFinding {get; private set; }
        public static PathFinding BFSPathFinding {get; private set; }
        public static SortingAlgorithm BoubleSorting {get; private set; }
        public static SortingAlgorithm Sorting {get; private set; }

        private void Awake()
        {
            APathFinding = GameObject.Find("APathFinding").GetComponent<PathFinding>();
            BFSPathFinding = GameObject.Find("BFSPathFinding").GetComponent<PathFinding>();
            Sorting = GameObject.Find("Sorting").GetComponent<SortingAlgorithm>();
            BoubleSorting = GameObject.Find("BoubleSorting").GetComponent<SortingAlgorithm>();
        }

    }
}

