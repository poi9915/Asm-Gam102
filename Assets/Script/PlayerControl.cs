using UnityEngine;

namespace Script
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float fallMultiplier;
        [SerializeField] private int jumpCount = 0;

        [SerializeField] private float counter;
        [SerializeField] private bool isGrounded;
        [SerializeField] private bool isDead;
        [SerializeField] private float speedUpCounter;
        [SerializeField] private float groundDetectionRadius;

        private Animator _animator;
        private float _hp;
        private Rigidbody2D _rb2d;

        private CapsuleCollider2D _col2d;

        // Start is called before the first frame update
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _col2d = GetComponent<CapsuleCollider2D>();
            _animator = GetComponent<Animator>();
            isDead = false;
            speedUpCounter = counter;
        }

        // Update is called once per frame
        void Update()
        {
            GroundedCheck();
            if (Input.GetKeyDown("space") && jumpCount < 2)
            {
                Jump();
            }

            speedUpCounter -= Time.deltaTime;
            if (speedUpCounter < 0)
            {
                moveSpeed++;
                speedUpCounter = counter;
            }
        }

        void FixedUpdate()
        {
            Move();
            if (_rb2d.velocity.y < 0)
            {
                _rb2d.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
            }
        }

        private void Move()
        {
            _rb2d.velocity = new Vector2(moveSpeed, _rb2d.velocity.y);
        }

        private void Jump()
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpForce);
            jumpCount++;
        }

        private void GroundedCheck()
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionRadius,
                LayerMask.GetMask("Ground"));
            Debug.DrawRay(transform.position, Vector2.down * groundDetectionRadius, Color.red);
            if (ray.collider is not null)
            {
                isGrounded = true;
                jumpCount = 0;
            }
            else
            {
                isGrounded = false;
            }
        }

        public float GetMoveSpeed()
        {
            return moveSpeed;
        }
    }
}