using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private static readonly int WalkingTransition = Animator.StringToHash("Walking");
    private static readonly int FloorTransition = Animator.StringToHash("OnFloor");
    private SpriteRenderer _theSprite;
    private bool _facingLeft = true;
    private Animator _animator;
    

    private void Start()
    {
        _theSprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void FacingLeft(bool isFacingLeft)
    {
        if (_facingLeft != isFacingLeft)
        {
            _facingLeft = isFacingLeft;
            _theSprite.flipX = !_facingLeft;
        }
    }

    public void Walking(bool isWalking)
    {
        _animator.SetBool(WalkingTransition, isWalking);
    }

    public void OnFloor(bool onFloor)
    {
        _animator.SetBool(FloorTransition, onFloor);
    }
}
