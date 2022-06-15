using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class GirlsReaction : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    public Transform point1, point2;
    public GameObject heartParticle;
    public Cloth cloth;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        //StartCoroutine(GetIntoThePool());
    }

    public IEnumerator GetIntoThePool()
    {
        cloth.enabled = true;
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("jump");
        yield return new WaitForSeconds(0.5f);

        DOTween.Sequence().Append(transform.DOMove(point1.position, 0.5f))
            .Append(transform.DOMove(point2.position, 0.5f)).OnComplete(() =>
            {
                _animator.SetTrigger("sit");
                //heartParticle.SetActive(true);
            });
    }
}
