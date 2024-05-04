using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float RunSpeed;//�����ƶ��ٶ�

    private Rigidbody2D myRigibody;//�����������
    private Animator myAnima;//������������


    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();//��ȡ�������
        myAnima = GetComponent<Animator>();//��ȡ�������
    }

    // Update is called once per frame
    void Update()
    {
        Run();//�����ܲ�
        Flip();//���Ƿ����ƶ�
    }

    void Flip()
    {
        bool IsMove = Mathf.Abs(myRigibody.velocity.x) > Mathf.Epsilon;//�ж������Ƿ���x�����ƶ�
        if (IsMove)
        {
            if (myRigibody.velocity.x > 0.1f)//�ж������Ƿ���x�������ƶ�
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (myRigibody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");//��ȡ�����ƶ��ķ���
        Vector2 player_run = new Vector2(moveDir * RunSpeed, myRigibody.velocity.y);//ʹ�����ڵ�ǰ�����ƶ�
        myRigibody.velocity = player_run;

        bool IsRun = Mathf.Abs(myRigibody.velocity.x) > Mathf.Epsilon;
        myAnima.SetBool("IsRun", IsRun);//������IsRun��ֵ�������Ƿ����ƶ�
    }
}
