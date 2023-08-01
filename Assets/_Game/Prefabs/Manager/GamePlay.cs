using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;


public class GamePlay : MonoBehaviour
{
    private static GamePlay instance;
    public static GamePlay Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<GamePlay>();
            }
            return instance;
        }
    }
    [SerializeField] GameObject[] panels;

    int level;

    void Start()
    {
        OpenUI(GameState.Play);
        level = PlayerPrefs.GetInt("Level",0);
    }
    void Update()
    {
        
    }

    private void CloseAll(){
        foreach (var item in panels)
        {
            item.SetActive(false);
        }
    }
    public void OpenUI(GameState state){
        CloseAll();
        panels[(int)state].SetActive(true);
    }
    
   
}
