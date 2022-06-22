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
    public Cloth[] cloth;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        //StartCoroutine(GetIntoThePool());
    }

    public IEnumerator GetIntoThePool(string anim)
    {
        for (int i = 0; i < cloth.Length; i++)
        {
            cloth[i].enabled = true;
        }
        
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("jump");
        yield return new WaitForSeconds(0.5f);

        DOTween.Sequence().Append(transform.DOMove(point1.position, 0.5f))
            .Append(transform.DOMove(point2.position, 0.5f)).OnComplete(() =>
            {
                _animator.SetTrigger(anim);
                if(anim == "freeze")
                {
                    Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 6,
                        transform.position.z);
                    Transform freezeEmoji = Instantiate(EffectsManager.instance.freezeEmojiReaction, spawnPos,
                        Quaternion.identity).transform;
                    freezeEmoji.transform.DOScale(Vector3.zero, 0.4f).From();
                }
                //heartParticle.SetActive(true);
            });
    }
}
