using System;
using UnityEngine;

namespace Script.Object
{
    public class DiamondControl : MonoBehaviour
    {
        private static readonly int IsCollect = Animator.StringToHash("isCollect");
        private Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        // void Update()
        // {
        //     // CheckGround();
        // }
        // Update is called once per frame
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _animator.SetTrigger(IsCollect);
            }
            
        }
        // private void CheckGround()
        // {
        //     RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 50f,
        //         LayerMask.GetMask("Ground"));
        //     Debug.DrawRay(transform.position, Vector2.down * 50f, Color.red);
        //     if (ray.collider is null)
        //     {
        //         Destroy(gameObject);
        //     }
        // }
        public void DestroySelf()
        {
            Destroy(this.gameObject);
        }
    }
}