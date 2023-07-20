using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iswin : MonoBehaviour
{
    void Update()
    {
        GameObject[] enemies= GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemies.Length;
        if( enemyCount == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
