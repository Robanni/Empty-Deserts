using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _speed = 4f;
    private float _jumpForce = 35f;
    private Rigidbody2D _playerRidgiedBody;
    public FixedJoystick PlayerJoystick;
    public Button JumpButton;
    

    void Start()
    {
        _playerRidgiedBody = GetComponent<Rigidbody2D>();
        JumpButton.ButtonClickedEvent += PlayerJump;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        _playerRidgiedBody.velocity = new Vector2(PlayerJoystick.Horizontal * _speed, _playerRidgiedBody.velocity.y);
        PlayerFlip(PlayerJoystick.Horizontal);
    }
    private void PlayerJump()
    {
        _playerRidgiedBody.AddForce(Vector2.up * _jumpForce,ForceMode2D.Impulse);
    }

    private void PlayerFlip(float diractionOfFlip)
    {

        if (diractionOfFlip > 0)
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        if (diractionOfFlip < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
