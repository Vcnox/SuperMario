using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    private Animator _animator;
    private PlatformMovement platformMovement;
    private SpriteRenderer _rend;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        platformMovement = GetComponent<PlatformMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (platformMovement.GetCurrentState())
        {
            case PlayerState.IDLE:
                _animator.SetBool("isWalking", false);
                break;

            case PlayerState.WALKING:
                _animator.SetBool("isWalking", true);
                break;
        }






    }
}
