using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人移动
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    //玩家位置
    public Transform PlayerTransform;
	//敌人移动速度
    public float speed = 5;
	//敌人每次运行距离
    public int step = 1;
	//下一次运行的x,z坐标
    public int x = 0;//左右
    public int z = 0;//前后
	//运行速度,改变velocity越小速度越快
    public float velocity = 0.5f;
    //敌人上的刚体组件
    private Rigidbody rd;
    //敌人下一步位置
    private Vector3 NextPosition;
    void Start()
    {
        NextPosition = transform.position;
		//重复调用EnemyMove,参数二表示第一次开始执行的时间,velocity越小执行方法频率越快
		InvokeRepeating("EnemyMove", 1, velocity);
    }
	void FixedUpdate()
    {
        //Lerp插值移动,当NextPosition值改变时敌人开始移动
        rd.MovePosition(Vector3.Lerp(transform.position, NextPosition, Time.deltaTime * speed));
    }
    // 敌人行为
    public void EnemyMove()
    {
        //获得敌人到玩家的偏移
        Vector3 offset = PlayerTransform.position - transform.position;
        //判断,当玩家是否处于自己的攻击距离的时候(小于12),enmey攻击
        if (offset.magnitude < 12)
        { 
			//TODO:Attack
			//当玩家与敌人距离小于12时,敌人开始攻击,因为我写的是射击类游戏所以攻击距离较大,可根据自己项目修改
        }
        //当玩家与敌人距离大于12时,敌人向玩家靠近移动
        else
        { 
            //通过偏移判断优先向那个(轴)方向移动
            if (Mathf.Abs(offset.z) > Mathf.Abs(offset.x))
            {
                //z轴移动
				//当offset偏移量大于0时,说明敌人Z轴坐标比玩家Z轴坐标小,下面同理
                if (offset.z > 0)
                { 
                   x = 0;
                   z = step;
                }
                else
                {
                   x = 0;
                   z = -step;
                   
                }
            }
            else
            {
                //x轴移动
                if (offset.x > 0)
                {
                   x = step;
                   z = 0;
                   
                }
                else
                {
                   x = -step;
                   z = 0;
                }
            }
			//设置下一步位置
            NextPosition = transform.position + new Vector3(x, 0, z);
        }
    }

 
}
