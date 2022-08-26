using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 1.0f;

    private void Update()
    {
        //Vector3 dir = new Vector3(1.0f,0.0f,0.0f);
        //transform.position += speed * Time.deltaTime * dir;
        transform.position += (speed * Time.deltaTime * Vector3.right ); //Space.Self : 자기기준, Space.World : 씬 기준
    }
}
