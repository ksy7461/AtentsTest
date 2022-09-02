using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    GameObject explosion;

    float spawnY;          //생성 됬을때의 높이
    float timeElapsed;     //게임 시작부터 얼마나 시간이 지났나를 기록해 놓는 함수


    private void Start()
    {
        explosion = transform.GetChild(0).gameObject;
        //explosion.SetActive(false);
        spawnY = transform.position.y;
        timeElapsed = 0.0f;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime; //Time.deltaTime 이전 프레임에서 현재 프레임까지의 시간
        float NewY = spawnY + Mathf.Sin(timeElapsed);  // Mathf.Sin sin함수 -1~1
        float NewX = transform.position.x - speed * Time.deltaTime;

        transform.position = new Vector3(NewX,NewY,0.0f);

        //transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World);
        //transform.Translate(speed * Time.deltaTime * new Vector3(-1,0), Space.Self);  // new로 새로 만들기 때문에 Vector3.left를 쓰는 것보다는 느리다.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //GameObject obj = Instantiate(explosion,transform.position,Quaternion.identity);
            //Destroy(obj,0.42f);
            explosion.SetActive(true);
            explosion.transform.parent = null; //부모와의 연결 해제

            Destroy(this.gameObject);
        }
    }
}