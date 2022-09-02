using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 1.0f;
    public float lifeTime = 3.0f;

    public GameObject hitEffect;

    private void Start()
    {
        Destroy(this.gameObject,lifeTime);
    }


    private void Update()
    {
        //Vector3 dir = new Vector3(1.0f,0.0f,0.0f);
        //transform.position += speed * Time.deltaTime * dir;
        //transform.position += (speed * Time.deltaTime * Vector3.right ); 
        transform.Translate(speed * Time.deltaTime * Vector3.right, Space.Self); //Space.Self : 자기기준, Space.World : 씬 기준
    }


    //충돌한 대상이 컬라이더 일때 실행
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision : {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitEffect.transform.parent = null;
            hitEffect.transform.position = collision.contacts[0].point;
            //collision.contacts[0].normal : 법선벡터(노멀벡터)
            //노멀벡터 : 특정 평면에 수직인 벡터
            //노멀 벡터는 반사를 계산힉 위해 필요하다 => 반사를 이용해서 그림자를 계산한다. 물리적인 반사도 계산한다.
            // 노말 벡터를 구하기 위해 벡터의 외적을 사용한다.
            hitEffect.gameObject.SetActive(true);

            Destroy(this.gameObject);
        }

        //매우 좋지 못한 코드
        //1. CompareTag는 숫자와 숫자를 비교하지만 == 은 문자열을 비교하여 더 느리다.
        //2. 필요없는 가비지가 생긴다.
        //if(collision.gameObject.tag == "Enemy")
        //{

        //}
    }

    //충돌한 대상이 트리거일 때 실행
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger : {collision.gameObject.name}");
    }
}
