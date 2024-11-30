using System;
using UnityEngine;

namespace Script.Enemy
{
    public class SeashellControl : MonoBehaviour, IEnemy
    {
        private static readonly int IsTarget = Animator.StringToHash("isTarget");
        [SerializeField] private GameObject point;
        [SerializeField] private GameObject bullet;
        private Animator animator;
        private bool _isTarget;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            animator.SetBool(IsTarget, _isTarget);
            PlayerDetected();
        }

        private void PlayerDetected()
        {
            RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.left, 5f
                , LayerMask.GetMask("Player"));
            Debug.DrawRay(point.transform.position, Vector2.left * 5f, Color.red);
            if (hit.collider is not null)
            {
                _isTarget = true;
            }
            else
            {
                _isTarget = false;
            }
        }

        public void Shoot()
        {
            Instantiate(bullet, point.transform.position, Quaternion.identity);
        }

        public void GetHit()
        {
            Destroy(this.gameObject);
        }
    }
}