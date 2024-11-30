using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Object
{
    public class SeashellBullet : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private float speed = 20;

        [SerializeField] private float counter = 2;

        // Update is called once per frame
        void Update()
        {
            Destroy(gameObject, 10);


            transform.Translate(Vector2.left * (speed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}