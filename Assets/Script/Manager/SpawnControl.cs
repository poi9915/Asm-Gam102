using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Manager
{
    public class SpawnControl : MonoBehaviour
    {
        public GameObject crab;
        public GameObject seashell;
        public float timeBetweenSpawns ;


        private void Update()
        {
            timeBetweenSpawns -= Time.deltaTime;
            if (timeBetweenSpawns < 0)
            {
                if (Random.Range(0, 2) == 0)
                {
                    Instantiate(crab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(seashell, transform.position, Quaternion.identity);
                }

                timeBetweenSpawns = 5;
            }
        }
    }
}