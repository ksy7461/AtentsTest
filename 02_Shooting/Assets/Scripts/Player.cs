using System;
using System.Collections;
using System.Collections.Generic;
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

    float speed=5.0f;
    float boost = 1.0f;
    Vector3 dir = new Vector3();
    Rigidbody2D rigid;

    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 생성된 직후에 호출
    /// </summary>
    private void Awake()
    {
        inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>(); // 한번만 찾고 저장해서 계속 쓰기
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
        inputActions.Player.Fire.performed += OnFire;
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
        inputActions.Player.Fire.performed -= OnFire;
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
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        //Exception : 예외 상황( 무엇을 해야 할지 지정이 안되어 있는 예외 일때 )
        //throw new NotImplementedException(); //NtopImplemetedException을 실행해라 => 강제로 죽여라

        Debug.Log("이동 입력");
        //Vector2 tempdir = context.ReadValue<Vector2>();
        dir = context.ReadValue<Vector2>();
    }
    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("발사!");
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
