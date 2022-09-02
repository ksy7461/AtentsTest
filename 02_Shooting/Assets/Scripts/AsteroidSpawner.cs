using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : EnemySpawner

{

    public Transform destination;

    

    protected override IEnumerator Spawn()
    {
        while (true)    // 무한 반복
        {
            GameObject obj = Instantiate(spawnPrefab, transform);  // 생성하고 부모를 이 오브젝트로 설정
            obj.transform.Translate(0, Random.Range(minY, maxY), 0);    // 스폰 생성 범위 안에서 랜덤으로 높이 정하기

            Vector3 destPosition = destination.position + new Vector3(0.0f, Random.Range(minY, maxY), 0.0f); //목적지 위치 결정

            Asteroid asteroid = obj.GetComponent<Asteroid>();
            if(asteroid != null)
            {
                // 운석이 destPosition로 가는 방향을 만들고
                // direction을 방향벡터로 만들어 준다.
                asteroid.direction = (destPosition - asteroid.transform.position).normalized;
            }

            yield return new WaitForSeconds(interval);  // interval만큼 대기
        }
    }

    // 개발용 정보를 항상 그리는 함수
    protected override void OnDrawGizmos()
    {
        //Gizmos.color = new Color(1,0,0);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));
        if (destination != null)
        {
            destination = transform.GetChild(0);
        }
        Gizmos.DrawWireCube(destination.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));
    }

}

