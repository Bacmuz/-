using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomcontrol : MonoBehaviour
{
    public float timer = 0;    //计时器
    public GameObject BoomEffect;    //爆炸效果预设体
    public AudioClip audioClip;   //拖入音频源
    void Update()
    {
        timer += Time.deltaTime;    //计时器计时
        if(timer > 2)    //爆炸时间为2s
        {
            Instantiate(BoomEffect,transform.position,transform.rotation);    //产生爆炸效果
            AudioSource.PlayClipAtPoint(audioClip,transform.position);    //产生音效
            Collider[] colliders = Physics.OverlapSphere(transform.position,0.8f);    //获取周围的碰撞体
            foreach(Collider collider in colliders)
            {
                if(collider.tag == "Enemy")    //如果对象是敌人
                {
                    collider.GetComponent<Enemycontrol>().Gethit();    //对敌人造成伤害
                }
                else if(collider.tag == "Cube")    //如果对象是方块
                {
                    Destroy(collider.gameObject);    //销毁方块
                }
                else if(collider.tag == "Player")    //如果对象是玩家
                {
                    collider.GetComponent<Playercontrol>().GetHit();    //玩家掉血
                }
            }
            Destroy(gameObject);    //销毁自己
        }
    }
}
