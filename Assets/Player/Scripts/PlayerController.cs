using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _speed = 4f;
    private float _jumpForce = 35f;
    private Rigidbody2D _playerRidgiedBody;
    private Animator _playerAnimator;
    public FixedJoystick PlayerJoystick;
    public Button JumpButton;
    

    void Start()
    {
        _playerRidgiedBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
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

        _playerAnimator.SetFloat("Speed", Mathf.Abs(_playerRidgiedBody.velocity.x));

        PlayerFlip(PlayerJoystick.Horizontal);
    }
    private void PlayerJump()
    {
        _playerRidgiedBody.AddForce(Vector2.up * _jumpForce,ForceMode2D.Impulse);
        _playerAnimator.SetTrigger("IsJumping");
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
