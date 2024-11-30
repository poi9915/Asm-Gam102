using System;
using Script.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class SwordControl : MonoBehaviour
    {
        // Start is called before the first frame update
        private float _counter;
        [SerializeField] private float speed = 0.5f;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.right * (speed * Time.deltaTime));
            _counter -= Time.deltaTime;
            if (_counter == 0)
            {
                HideObject();
            }
        }

        private void OnEnable()
        {
            _counter = 20;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.gameObject.GetComponent<IEnemy>();
                enemy.GetHit();
                HideObject();
            }

            if (other.CompareTag("Ground"))
            {
                HideObject();
            }
        }

        public void HideObject()
        {
            this.gameObject.SetActive(false);
        }
    }
}