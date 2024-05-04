using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float RunSpeed;//主角移动速度

    private Rigidbody2D myRigibody;//声明刚体对象
    private Animator myAnima;//声明动画对象


    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();//获取刚体组件
        myAnima = GetComponent<Animator>();//获取动画组件
    }

    // Update is called once per frame
    void Update()
    {
        Run();//主角跑步
        Flip();//主角反向移动
    }

    void Flip()
    {
        bool IsMove = Mathf.Abs(myRigibody.velocity.x) > Mathf.Epsilon;//判断主角是否在x轴上移动
        if (IsMove)
        {
            if (myRigibody.velocity.x > 0.1f)//判断主角是否向x轴正向移动
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
        float moveDir = Input.GetAxis("Horizontal");//获取主角移动的方向
        Vector2 player_run = new Vector2(moveDir * RunSpeed, myRigibody.velocity.y);//使主角在当前方向移动
        myRigibody.velocity = player_run;

        bool IsRun = Mathf.Abs(myRigibody.velocity.x) > Mathf.Epsilon;
        myAnima.SetBool("IsRun", IsRun);//将参数IsRun赋值上主角是否在移动
    }
}
