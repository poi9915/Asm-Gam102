using Script.Player;
using UnityEngine;

namespace Script
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Material bg1;
        [SerializeField] private Material bg2;
        [SerializeField] private Material bg3;
        [SerializeField] private PlayerControl player;
        private float _offSet1;
        private float _offSet2;
        private float _offSet3;


        private void Update()
        {
            _offSet1 += Time.deltaTime * player.GetMoveSpeed() * 0.01f;
            _offSet2 += Time.deltaTime * player.GetMoveSpeed() * 0.02f;
            _offSet3 += Time.deltaTime * player.GetMoveSpeed() * 0.03f;

            bg1.mainTextureOffset = new Vector2(_offSet1, 0);
            bg2.mainTextureOffset = new Vector2(_offSet2, 0);
            bg3.mainTextureOffset = new Vector2(_offSet3, 0);
        }
    }
}