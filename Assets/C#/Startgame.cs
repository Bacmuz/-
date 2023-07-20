using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{
   public void onClick()
    {
        SceneManager.LoadScene(1);  //要切换的场景的索引
    }
}
