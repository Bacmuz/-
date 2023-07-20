using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontrol : MonoBehaviour
{
    public float m_speed = 1.2f;  //速度
    public GameObject bombPrefab;   //炸弹预设体
    public float CD = 1;    //间隔时间
    public int hp = 1;    //血量
    public float timer = 0;    //计时器
    public GameObject Player;    //获取游戏对象
    void Update()
    {
        if(hp<=0)    //如果血量为0，则跳转至死亡面板
        {

            SceneManager.LoadScene(2);
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal"); //获取水平轴
            float vertical = Input.GetAxis("Vertical"); //垂直轴
            Vector3 dir = new Vector3(horizontal,0,vertical);   //获取向量
            if(dir != Vector3.zero)    //如果向量不为零，则在运动
            {
                transform.rotation = Quaternion.LookRotation(dir);  //角色朝向向量的方向
                transform.position += dir * m_speed * Time.deltaTime;   //进行移动
                //运动状态，播放移动动画
                transform.gameObject.GetComponent<Animator>().Play("run");

            }
            else
            {
                //静止状态，播放站立动画
                transform.gameObject.GetComponent<Animator>().Play("i");
            }

            timer += Time.deltaTime;    //计时器
            if(Input.GetKeyDown (KeyCode.Space)  && timer>=CD)   //按下空格键释放炸弹
                {
                timer = 0;    //重置CD
                Instantiate(bombPrefab, new Vector3(transform.position.x , (float)0.125 , transform.position.z),  transform.rotation);    //生成炸弹
            }
        }
    }

    public void GetHit()
    {
        hp -= 1;    //受到伤害Hp减1
    }
}
