using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Player
{
    public class SwordPooling : MonoBehaviour
    {
        public static SwordPooling Instance { get; set; }
        private List<GameObject> swordPool = new List<GameObject>();
        [SerializeField] int amountOfSwords;
        [SerializeField] GameObject swordPrefab;
        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            for (int i = 0; i < amountOfSwords; i++)
            {
                GameObject newSword = Instantiate(swordPrefab);
                swordPool.Add(newSword);
                newSword.SetActive(false);
            }
        }

        public GameObject GetSword()
        {
            for (int i = 0; i < swordPool.Count; i++)
            {
                if (!swordPool[i].activeInHierarchy)
                {
                    return swordPool[i];
                }
            }
            return null;
        }
    }
}