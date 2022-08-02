using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    
    //�ʿ�Ӽ� : ȸ���ӵ�
    public float rotSpeed = 205;
    //�츮�� ���� ������ ��������
    float mx;
    float my;
    void Start()
    {
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //������� ���콺 �Է¿� ���� ��ü�� �����¿�� ȸ����Ű�� �ʹ�.
        //3. ������� �Է¿� ����
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;
        my = Mathf.Clamp(my, -60f, 60f);
        //x�� -> pitch, y�� -> Yaw, z�� -> Roll
        transform.eulerAngles = new Vector3(-my, mx, 0);
        //2. ������ �ʿ�
        //Vector3 dir = new Vector3(-v, h, 0);

        //1. ȸ���ϰ��ʹ�.
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;
    }
}
