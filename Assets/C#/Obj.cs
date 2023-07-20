using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public GameObject obj;    //方块的预设体
    public GameObject Enemy;    //敌人的预设体
    void Start()
    {
        for (int i = 0; i < 20; i++) 
        {
        Instantiate(obj, new Vector3(Random.Range(-4,4), (float)0.25,Random.Range(-4,4)), Quaternion.identity);    //游戏开始随机生成20个方块
        }
        for (int i = 0; i < 2; i++) 
        {
        Instantiate(Enemy, new Vector3(Random.Range(-4,4), (float)0.25,Random.Range(-4,4)), Quaternion.identity);    //游戏开始随机生成2个敌人
        }
    }
}
