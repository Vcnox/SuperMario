using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;



public enum PlayerState { IDLE, WALKING, JUMP }


public class PlatformMovement : MonoBehaviour
{
    public float speed = 3, JumpForce = 1;
    public LayerMask _groundMask;
    public float _sphereRadius = 0.2f;
    private Rigidbody2D _rb2D;
    private Vector2 _Dir;
    private bool _IsJumping, _CanJump = false;

    [SerializeField]
    private PlayerState _currentState;



    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        _Dir = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (_Dir.magnitude == 0)  // Magnitud del vector
        {
            _currentState = PlayerState.IDLE;
        }
        else
        {
            _currentState = PlayerState.WALKING;
        }
        Jump();
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(_Dir.x * speed, _rb2D.velocity.y);
        ApplyYforce();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _IsJumping = true;
            _currentState = PlayerState.JUMP;
        }
    }

    void ApplyYforce()
    {
        if (_IsJumping)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, 0); // reseteamos fuerza en y para que siempre salga con la misma fuerza
            _rb2D.AddForce(Vector2.up * JumpForce * _rb2D.gravityScale, ForceMode2D.Impulse);
            _IsJumping = false;
        }
    }
    private bool IsGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), _sphereRadius, _groundMask); // indicamos una variable collider el cual detecte que al hacer contacto los pies con el suelo el player puede saltar

        return collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y), _sphereRadius); // dibuja una esfera del color que le des y se ajusta al tamaño dado por el usuario
    }

    public PlayerState GetCurrentState()
    {
        return _currentState;
    }

    public Vector2 GetDirection()
    {
        return _Dir;
    }

 
}
