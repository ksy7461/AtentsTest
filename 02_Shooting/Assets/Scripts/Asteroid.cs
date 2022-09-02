using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed = 360.0f; // 회전 속도
    public float moveSpeed = 3.0f; // 이동 속도

    public float minMoveSpeed = 2.0f;
    public float maxMoveSpeed = 4.0f;
    public float minRotateSpeed = 30.0f;
    public float maxRotateSpeed = 360.0f;

    public float lifeTime = 3.0f;

    public GameObject small;
    [Range(1,16)]
    public int splitCount = 3;

    int hitPoint = 3;

    public Vector3 direction = Vector3.left; // 운석이 이동할 방향

    GameObject explosion;

    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //switch (Random.Range(0, 4))
        //{
        //    case 0: 
        //        spriteRenderer.flipX = true; 
        //        break;
        //    case 1: 
        //        spriteRenderer.flipY = true; 
        //        break;
        //    case 2: 
        //        spriteRenderer.flipX = true; 
        //        spriteRenderer.flipY = true; 
        //        break;
        //    case 3: 
        //        break;
        //}
        int rand = Random.Range(0, 4);

        //(rand & 0b_01) : rand의 제일 오른쪽 비트가 0이냐 1이냐 확인하는 작업
        spriteRenderer.flipX = ((rand & 0b_01) != 0); //비트연산자 & | 
        spriteRenderer.flipY = ((rand & 0b_10) != 0); 

        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        //rotateSpeed = Random.Range(30.0f, 360.0f);
        //rotateSpeed = ((moveSpeed - minMoveSpeed) / (maxMoveSpeed-minMoveSpeed) * (maxRotateSpeed-minRotateSpeed)) + minRotateSpeed;
        rotateSpeed = Mathf.Lerp(minRotateSpeed, maxRotateSpeed, (moveSpeed - minMoveSpeed) / (maxMoveSpeed - minMoveSpeed)); //최솟값,최댓값,비율
        lifeTime = Random.Range(3.0f, 5.0f);
    }


    private void Start()
    {
        explosion = transform.GetChild(0).gameObject;
        StartCoroutine(timeCrush());

    }

    void Update()
    {
        //transform.rotation *= Quaternion.Euler(new(0, 0, 90));  // 계속 90도씩 회전
        //transform.rotation *= Quaternion.Euler(new(0, 0, rotateSpeed * Time.deltaTime));    // 1초에 rotateSpeed도씩 회전
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);   // Vector3.forward 축을 기준으로 1초에 rotateSpeed도씩 회전

        transform.Translate(moveSpeed*Time.deltaTime*direction,Space.World);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + direction*1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Bullet"))
        {

            hitPoint--;
            if (hitPoint <= 0)
            {
                //GameObject obj = Instantiate(explosion,transform.position,Quaternion.identity);
                //Destroy(obj,0.42f);
                Crush();
            }
        }

    }


    void Crush()
    {

        explosion.SetActive(true);
        explosion.transform.parent = null; //부모와의 연결 해제

        if (Random.Range(0.0f,1.0f)< 0.05f)
        {
            splitCount = 20;
            
        }
        else
        {
            splitCount = Random.Range(3, 10); // 1/7 확률로 3~9가 나온다.
        }


        float angleGap = 360.0f / (float)splitCount;
        float startAngle = Random.Range(0, angleGap);

        for (int i = 0; i < splitCount; i++)
        {
            Instantiate(small, transform.position, Quaternion.Euler(0, 0, startAngle + (angleGap) * i));
        }

        Destroy(this.gameObject);

    }

    IEnumerator timeCrush()
    {
        yield return new WaitForSeconds(lifeTime);
        Crush();
    }

}
