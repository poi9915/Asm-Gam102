using UnityEngine;

namespace Script.Enemy
{
    public class CrabbyControl : MonoBehaviour, IEnemy
    {
        [SerializeField] private int hitCounter = 0;
        [SerializeField] private float moveSpeed = 2.5f;
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;

        private Transform _currentTarget;
        private Rigidbody2D _rb2d;

        void Start()
        {
            // Set initial target to pointA
            _currentTarget = pointA;
            _rb2d = GetComponent<Rigidbody2D>();
            pointA.SetParent(null);
            pointB.SetParent(null);
        }

        void Flip()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        void Update()
        {
            if (CheckGround())
            {
                MoveBetween();
            }
        }

        private void MoveBetween()
        {
            Vector2 direction = (_currentTarget.position - transform.position).normalized;
            _rb2d.velocity = direction * moveSpeed;

            if (Vector2.Distance(transform.position, _currentTarget.position) < 0.5f)
            {
                Flip();
                _currentTarget = _currentTarget == pointA ? pointB : pointA;
            }
        }

        private bool CheckGround()
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 0.5f,
                LayerMask.GetMask("Ground"));
            Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.red);
            return ray.collider is not null;
        }

        public void GetHit()
        {
            hitCounter++;
            if (hitCounter == 2)
            {
                Destroy(gameObject);
            }
        }
    }
}