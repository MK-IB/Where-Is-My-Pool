using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSetter : MonoBehaviour
{
    public int animInt;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetInteger("animValue", animInt);
    }
}
