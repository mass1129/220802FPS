using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������� �Է¿� ���� �յ��¿�� �̵��ϰ� �ʹ�.
//�ʿ�Ӽ� : �̵��ӵ�
//cc�� �̿��� �̵��ϰ� �ʹ�.
//�ʿ�Ӽ� :  cc
//�߷��� �����ϰ� �ʹ�.
//�ʼ� : �߷°�, �����ӵ�.
public class PlayerMove : MonoBehaviour
{
    //�ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;
    CharacterController cc;
    //�ʼ� : �߷°�, �����ӵ�.
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
        //�����ӵ� ���ϱ�
        yVelocity += gravity*Time.deltaTime;
        //���� �ٴڿ� ����ִٸ�
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            //->�����ӵ��� 0���� �ϰ� �ʹ�.
            yVelocity = 0;
        }


        dir.y = yVelocity;

        //transform.position += dir*speed*Time.deltaTime;
        cc.Move(dir * speed * Time.deltaTime);

        
    }
}
