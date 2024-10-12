using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;
    public float _playerSpeed;
    private Vector2 _playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>(); 
        _playerAnimator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {

        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (_playerDirection.sqrMagnitude > 0)
        {
            if(_playerDirection.y != 0){
                _playerAnimator.SetInteger("Movement", 0);
            } else {
                _playerAnimator.SetInteger("Movement", 1);
            }
        } else {
            _playerAnimator.SetInteger("Movement", 0);
        }
        Direction();

        // Debug.Log("O valor de Movement é: " +  _playerAnimator.GetInteger("Movement"));
        
    }

    void FixedUpdate(){
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }

    void Direction() {
        if(_playerDirection.y > 0){
            _playerAnimator.SetInteger("Direction", 2);
        } else if(_playerDirection.y < 0) {
            _playerAnimator.SetInteger("Direction", 1);
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
    }
}
