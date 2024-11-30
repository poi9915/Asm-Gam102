using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Script.Manager
{
    public class CoinSpawn : MonoBehaviour
    {
        public GameObject coinPrefab;
        [SerializeField] private float counter = 2.5f;
        public Transform player;

        private void Update()
        {
            counter -= Time.deltaTime;

            if (counter < 0)
            {
                Vector2 xPoss = new Vector2(transform.position.x,
                    Random.Range(player.position.y, player.position.y + 0.3f));
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(coinPrefab, xPoss, Quaternion.identity);
                }

                counter = 2.5f;
            }
        }
    }
}