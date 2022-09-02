using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트를 가지는 게임 오브젝트는 반드시 Animator를 가진다.
[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{

    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //이게임 오브젝트가 활성화되면
        // anim.GetCurrentAnimatorClipInfo(0)[0].clip.length 시간후에 파괴하라
        Destroy(this.gameObject, anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
    }
}
