using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    Vector3 _moveVector;
    float _fallVelocity = 0;

    CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _moveVector = Vector3.zero;
        animator.SetFloat("speed", 0);

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            animator.SetFloat("speed", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            animator.SetFloat("speed", -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("speed", 1);
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("speed", 1);
            _moveVector -= transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            animator.SetBool("isGrounded", false);
        }
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("isGrounded", true);
        }
    }
}
