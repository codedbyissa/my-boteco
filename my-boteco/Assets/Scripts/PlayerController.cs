using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;
    public float _playerSpeed;
    private Vector2 _playerDirection;

    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>(); 
        _playerAnimator = GetComponent<Animator>(); 
    }

    void Update()
    {
        _playerDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _playerDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _playerDirection.y = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerDirection.x = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerDirection.x = -1;
        }

        if (_playerDirection.sqrMagnitude > 0)
        {
            if (_playerDirection.y != 0)
            {
                _playerAnimator.SetInteger("Movement", 0);
            }
            else
            {
                _playerAnimator.SetInteger("Movement", 1);
            }
        }
        else
        {
            _playerAnimator.SetInteger("Movement", 0);
        }

        Direction();
    }

    void FixedUpdate()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }

    void Direction() {

        if(_playerDirection.y > 0){
            _playerAnimator.SetInteger("Direction", 2);
            _playerAnimator.SetInteger("StaticDirection", 0);
        } else if(_playerDirection.y < 0) {
            _playerAnimator.SetInteger("Direction", 1);
            _playerAnimator.SetInteger("StaticDirection", 0);
        } else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {  
            _playerAnimator.SetInteger("Direction", 0);
        } else {
            _playerAnimator.SetInteger("Direction", 0);
            if(_playerDirection.x > 0){
                transform.eulerAngles =  new Vector2(0f, 0f);
            } else if(_playerDirection.x < 0){
                transform.eulerAngles = new Vector2(0f, 180f);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            _playerAnimator.SetInteger("StaticDirection", 1);
        } else if(Input.GetKeyDown(KeyCode.RightArrow)){
            _playerAnimator.SetInteger("StaticDirection", 1);
        } else if(Input.GetKeyUp(KeyCode.UpArrow)){
            _playerAnimator.SetInteger("StaticDirection", 2);
        } else if(Input.GetKeyUp(KeyCode.DownArrow)) {
            _playerAnimator.SetInteger("StaticDirection", 3);
        }

              
    }
}
