using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //delegate 함수를 저장하는 변수일이 발생하는 클래스와 기능이 실행되어야 하는 클래스가 서로 다를 때 유용하게 사용할 수 있다.
    //public delegate void DelegateName(); //이런 종류의 delegate가 있다(리턴도없고 파라메터도 없는 함수를 저장하는 delegate)

    //public DelegateName del; // DelegateName 타입으로 del이라는 이름의 델리게이트를 만듬
    //Action del2; //리턴타입이 void, 파라메터도 없는 delegate를 만듬
    //Action<int> del3; //리턴타임이 void, 파라메터는 int 하나인 delegate
    //Func<int,float> del4; //리턴타입이 int이고 파라메터는 float 하나인 delegate
    
    PlayerInputAction inputActions;
    Animator anim;

    public float speed=5.0f;
    public GameObject bullet;
    public GameObject stone;
    public float fireInterval = 0.5f;

    IEnumerator fireCoroutine;

    float boost = 1.0f;
    //float spawnTime = 0;
    //float spawnTimeMax = 1;
    Vector3 dir = new Vector3();
    Rigidbody2D rigid;

    Transform[] firePosition; // 트랜스폼을 여러개 가지는 배열
    public GameObject flash;

    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 생성된 직후에 호출
    /// </summary>
    private void Awake()
    {
        inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>(); // 한번만 찾고 저장해서 계속 쓰기
        anim = GetComponent<Animator>();

        firePosition = new Transform[transform.childCount-1];
        for (int i = 0; i < transform.childCount-1; i++)
        {
            firePosition[i] = transform.GetChild(i);
        }
        //flash = transform.GetChild[transform.childCount - 1].gameObject;

        fireCoroutine = Fire();
        // Awake -> InEnable -> Start : 대체적으로 이 순서
    }

    /// <summary>
    /// 이 스크립트가 들어가이쓴ㄴ 게임 오브젝트가 활성화 되었을 때 호출
    /// </summary>
    private void OnEnable()
    {
        inputActions.Player.Enable(); // 오브젝트가 생성되면 입력을 받도록 활성화
        inputActions.Player.Move.performed += OnMove; //performed일 떄 OnMove 함수 실행되도록 연결
        inputActions.Player.Move.canceled += OnMove; // canceled일 때 OnMove 함수 실행되도록 연결
        //inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Fire.performed += OnFireStart;
        inputActions.Player.Fire.canceled += OnFireStop;
        inputActions.Player.Booster.performed += OnBooster;
        inputActions.Player.Booster.canceled += OnBooster;
    }


    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 비활성화 되었을 때 호출
    /// </summary>
    private void OnDisable()
    {
        inputActions.Player.Booster.canceled -= OnBooster;
        inputActions.Player.Booster.performed -= OnBooster;
        //inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Fire.canceled -= OnFireStop;
        inputActions.Player.Fire.performed -= OnFireStart;
        inputActions.Player.Move.canceled -= OnMove; //연결해 놓은 함수 해제(안전을위해)
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable(); // 오브젝트가 사라질 때 더이상 입력을 받지 않도록 
    }

    /// <summary>
    /// 시작할 때. 첫번째 Update 함수가 실행되기 직전에 호출
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// 매 프레임마다 호출.
    /// </summary>
    //private void Update()
    //{
    //    //transform.position += speed * Time.deltaTime * dir;
    //    //transform.Translate(speed * Time.deltaTime * dir);
    //}

    /// <summary>
    /// 일정 시간 간격으로 호출 (물리 업데이트 시간 간격)
    /// </summary>
    private void FixedUpdate()
    {
        //transform.Translate(speed * Time.fixedDeltaTime * dir);
        //Rigidbody2D rigid = GetComponent<Rigidbody2D>(); //이 스크립트 파일이 들어 있는 게임 오브젝트에서 Rigidbody2D컴포넌트를 찾아 리턴
        //gEtCompnent는 무거운 함수 => (Update나 FixedUpdate처럼 주기적 또는 자주 호출되는 함수 안에서는 안쓰는 것이 좋다)

        //rigid.AddForce(speed * Time.fixedDeltaTime * dir); //관성있는 움직임
        rigid.MovePosition(transform.position + speed * Time.fixedDeltaTime * boost * dir);

        //spawnTime += Time.deltaTime;
        //if (spawnTime > spawnTimeMax)
        //{
        //    float value = Random.Range(-8.0f, 8.0f);
        //    Vector3 vec3 = new Vector3(value, 5.0f);
        //    Instantiate(stone, vec3, Quaternion.identity);
        //    spawnTime = 0;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("OnCollisionEnter2D");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("OnCollisionStay2D");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("OnCollisionExit2D");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter2D");
        //Debug.Log("게임 오버");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerStay2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerExit2D");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        //Exception : 예외 상황( 무엇을 해야 할지 지정이 안되어 있는 예외 일때 )
        //throw new NotImplementedException(); //NtopImplemetedException을 실행해라 => 강제로 죽여라

        //Debug.Log("이동 입력");
        //Vector2 tempdir = context.ReadValue<Vector2>();
        dir = context.ReadValue<Vector2>();

        anim.SetFloat("InputY",dir.y);
    }
    private void OnFireStart(InputAction.CallbackContext _)
    {
        //Debug.Log("발사!");
        //float value = Random.Range(0.0f, 10.0f);  // value에는 0.0 ~ 10.0의 랜덤값이 들어간다.
        //isFiring = true;
        StartCoroutine(fireCoroutine);

    }

    private void OnFireStop(InputAction.CallbackContext _)
    {
        //isFiring = false;
        //StopAllCoroutines();
        StopCoroutine(fireCoroutine);
    }

    IEnumerator Fire()
    {
        //yield return null;      // 다음 프레임에 이어서 시작해라
        //yield return new WaitForSeconds(1.0f);  // 1초 후에 이어서 시작해라

        while (true)
        {
            for (int i = 0; i < firePosition.Length; i++)
            {
                Instantiate(bullet, firePosition[i].position, firePosition[i].rotation);

                //GameObject obj = Instantiate(bullet, firePosition[i].position, Quaternion.identity);
                //obj.transform.rotation = firePosition[i].rotation;  //firePosition[i]의 회전값을 그대로 사용한다.
                //Vector3 angle = firePosition[i].rotation.eulerAngles; // 현제 회전 값을 x,y,z축 별로 몇도씩 회전했는지 확인
            }
            flash.SetActive(true);
            StartCoroutine(FlashOff());

            yield return new WaitForSeconds(fireInterval);
        }
    }

    IEnumerator FlashOff()
    {
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
    }

    private void OnBooster(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            boost = 1.0f;
        }
        if (context.performed)
        {
            boost *= 2.0f;
        }
    }



}
