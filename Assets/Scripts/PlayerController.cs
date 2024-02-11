using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce;
    public float Speed;


    private Vector3 _moveVector = Vector3.zero;
    private float _fallVelocity = 1;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Debug.Log(_moveVector);
    }

    void Update()
    {
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= Vector3.right;
        }

        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _fallVelocity = -JumpForce;
        }
        Debug.Log(_moveVector);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        _fallVelocity += Time.fixedDeltaTime * Gravity;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
