using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInputAction inputActions;

    float speed=5.0f;
    Vector3 dir;

    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 생성된 직후에 호출
    /// </summary>
    private void Awake()
    {
        inputActions = new PlayerInputAction();
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
    }

    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 비활성화 되었을 때 호출
    /// </summary>
    private void OnDisable()
    {
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
    private void Update()
    {
        transform.position += speed * Time.deltaTime * dir;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        //Exception : 예외 상황( 무엇을 해야 할지 지정이 안되어 있는 예외 일때 )
        //throw new NotImplementedException(); //NtopImplemetedException을 실행해라 => 강제로 죽여라

        Debug.Log("이동 입력");
        Vector2 inputDir = context.ReadValue<Vector2>();
        dir = inputDir;
    }
    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("발사!");
    }



}
