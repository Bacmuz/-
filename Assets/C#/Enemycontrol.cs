using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontrol : MonoBehaviour
{
    private Playercontrol player;    //玩家
    public int Hp = 1;    //敌人血量
    public  float Speed = 0.8f;    //敌人速度

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Playercontrol>();    //获取玩家
    }

    void Update()
    {
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            float dis = Vector3.Distance(player.transform.position, transform.position);    //获取玩家和敌人之间的距离
            if(dis < 2 && dis > 0.8f)
            {
                transform.LookAt(player.transform);    //距离小于2会看向玩家
                transform.Translate(Vector3.forward * Speed * Time.deltaTime);    //朝前走去
                transform.gameObject.GetComponent<Animator>().Play("run");    //播放运动动画
            }
            else
            {   
                transform.gameObject.GetComponent<Animator>().Play("idel");    //播放静止动画
            }
        }
    }

    public void Gethit()
    {
        Hp -= 1;
    }
}
