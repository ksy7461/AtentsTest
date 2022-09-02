using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 필요한 변수가 무엇인가? -> Enemy 프리팹, 지속적으로 동작을 하는 시간 간격

    public GameObject spawnPrefab;        // 생성할 적의 프리팹
    public float interval = 0.5f;   // 생성할 시간 간격

    protected float minY = -4.0f;     // 스폰이 일어나는 최저 높이
    protected float maxY = 4.0f;      // 스폰이 일어나는 최고 높이


    // 필요한 기능은 무엇인가? -> Enemy 프리팹을 생성하는 코루틴
    private void Awake()
    {
        // 오브젝트가 생성된 직후 = > 이 오브젝트 안에 있는 것들이 초기화 할 때 사용
        // 이 오브젝트 안에 있는 모든 컴퍼넌트가 생성이 완료
        // 그리고 이 오브젝트의 자식 오브젝트들도 모두 생성 완료
        //destination = transform.Find("DetinationArea"); // "DestinationArea"라는 일므을 가진 자식 찾기
        //destination = transform.GetChild(0); // 첫번째 자식 찾기
    }

    private void Start()
    {
        // 첫번째 업데이트 실행 직전 호출
        // 나와 다른 오브젝트를 가져와야 할 때 사용
        StartCoroutine(Spawn());
    }
    protected virtual IEnumerator Spawn()
    {

        while (true)    // 무한 반복
        {
            GameObject obj = Instantiate(spawnPrefab, transform);  // 생성하고 부모를 이 오브젝트로 설정
            obj.transform.Translate(0, Random.Range(minY, maxY), 0);    // 스폰 생성 범위 안에서 랜덤으로 높이 정하기
            yield return new WaitForSeconds(interval);  // interval만큼 대기
        }
    }

    // 개발용 정보를 항상 그리는 함수
    protected virtual void OnDrawGizmos()
    {
        //Gizmos.color = new Color(1,0,0);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));
    }

    // 개발용 정보를 선택되었을 때만 그리는 함수
    //private void OnDrawGizmosSelected()
    //{        
    //}
}
