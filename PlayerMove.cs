using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자의 입력에 따라 앞뒤좌우로 이동하고 싶다.
//필요속성 : 이동속도
//cc를 이용해 이동하고 싶다.
//필요속성 :  cc
//중력을 적용하고 싶다.
//필속 : 중력값, 수직속도.
public class PlayerMove : MonoBehaviour
{
    //필요속성 : 이동속도
    public float speed = 5;
    CharacterController cc;
    //필속 : 중력값, 수직속도.
    public float gravity = -20;
    float yVelocity = 0;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        //수직속도 구하기
        yVelocity += gravity*Time.deltaTime;
        //만약 바닥에 닿아있다면
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            //->수직속도를 0으로 하고 싶다.
            yVelocity = 0;
        }


        dir.y = yVelocity;

        //transform.position += dir*speed*Time.deltaTime;
        cc.Move(dir * speed * Time.deltaTime);

        
    }
}
