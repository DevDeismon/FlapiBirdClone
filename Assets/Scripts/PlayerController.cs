using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force;
    private Rigidbody2D _playerRb;
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
