using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private static GameStart instance;
    public static GameStart Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<GameStart>();
            }
            return instance;
        }
    }
   
}
