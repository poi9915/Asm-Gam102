using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneControl : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.position.x, transform.position.y);
    }
}