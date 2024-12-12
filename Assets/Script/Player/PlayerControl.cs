using System;
using Script.Enemy;
using Script.Manager;
using Script.Object;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Script.Player
{
    public class PlayerControl : MonoBehaviour
    {
        private static readonly int IsJump = Animator.StringToHash("isJump");
        private static readonly int IsShoot = Animator.StringToHash("isShoot");
        private static readonly int IsDead = Animator.StringToHash("isDead");
        private static readonly int IsHit = Animator.StringToHash("isHit");
        [SerializeField] private float jumpForce;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float fallMultiplier;
        [SerializeField] private int jumpCount = 0;
        [SerializeField] private Transform throwHand;
        [SerializeField] private float counter;
        [SerializeField] private bool isGrounded;
        [SerializeField] private bool isDead;
        [SerializeField] private float speedUpCounter;
        [SerializeField] private int hp;
        [SerializeField] private int maxHp = 10;
        [SerializeField] private float groundDetectionRadius;
        [SerializeField] private HpBarControl playerHp;

        [SerializeField] private float playerFlySpeed;

        //[SerializeField] private bool isShoot = false;
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
            hp = maxHp;
            playerHp.UpdateHp(hp, maxHp);
        }

        // Update is called once per frame
        void Update()
        {
            _animator.SetBool(IsDead, isDead);
            if (!isDead)
            {
                _animator.SetBool(IsJump, !isGrounded);
                GroundedCheck();
                if (Input.GetKeyDown("space") && jumpCount < 2)
                {
                    Jump();
                }

                if (Input.GetKey(KeyCode.F))
                {
                    Fly();
                }

                if (Input.GetKeyDown(KeyCode.J))
                {
                    // ThrowSword();
                    _animator.SetBool(IsShoot, true);
                }
                else
                {
                    _animator.SetBool(IsShoot, false);
                }

                speedUpCounter -= Time.deltaTime;
                if (speedUpCounter < 0)
                {
                    moveSpeed++;
                    speedUpCounter = counter;
                }

                EnemyDetect();
                if (_rb2d.velocity.y < 0)
                {
                    _rb2d.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
                }
            }
        }

        void FixedUpdate()
        {
            if (!isDead)
            {
                Move();
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

        private void ThrowSword()
        {
            GameObject sword = SwordPooling.Instance.GetSword();
            if (sword is not null)
            {
                sword.transform.position = throwHand.position;
                sword.SetActive(true);
            }
        }

        public void EnemyDetect()
        {
            // float DoDai = 10f;
            // Color xanh = Color.green;
            // RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, DoDai,
            //     LayerMask.GetMask("Enemy"));
            // Debug.DrawRay(transform.position, Vector2.right * DoDai, xanh);
            // if (ray.collider is not null)
            // {
            //     Destroy(ray.collider.gameObject);
            // }
            // LayerMask layerMask = LayerMask.GetMask("Enemy");
            // LayerMask layerMask2 = LayerMask.GetMask("Ground");
            //
        }

        public float GetMoveSpeed()
        {
            return moveSpeed;
        }

        private void Fly()
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpForce);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet") && !isDead)
            {
                Debug.Log(other.gameObject.name);
                GetHit();
            }

            if (other.CompareTag("Enemy"))
            {
                GetHit();
            }

            if (other.CompareTag("Diamond"))
            {
                GameManager.Instance.AddScore();
            }

            if (other.CompareTag("HpRec"))
            {
                if (hp < 10)
                {
                    hp = hp + 2;
                    playerHp.UpdateHp(hp, maxHp);
                    Destroy(other.gameObject);
                }
            }
        }

        private void Dead()
        {
            isDead = true;
            _rb2d.velocity = Vector2.zero;

            GameManager.Instance.ShowHighScoreBoard();
        }

        private void GetHit()
        {
            if (hp == 0)
            {
                Dead();
            }
            else
            {
                _animator.SetTrigger(IsHit);
                hp--;
                playerHp.UpdateHp(hp, maxHp);
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }
    }
}