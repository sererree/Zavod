using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float Gravity = 9.8f;
    public float JumpForce = 7;
    public float Speed = 5;
    public AudioSource sound;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;
  
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
           
            _moveVector += transform.forward;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
           
            _moveVector -= transform.forward;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
           
            _moveVector += transform.right;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (_moveVector != Vector3.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
            animator.SetBool("isGrounded", false);
        }
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("isGrounded", true);
        }
    }
}

