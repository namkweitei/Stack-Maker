using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { Play = 0, Win = 1, Lose = 2, Loading = 3 }
public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }
    [SerializeField] GameObject[] panels;



    void Start()
    {
        OpenUI(GameState.Loading);

    }
    void Update()
    {

    }

    private void CloseAll()
    {
        foreach (var item in panels)
        {
            item.SetActive(false);
        }
    }
    public void OpenUI(GameState state)
    {
        CloseAll();
        panels[(int)state].SetActive(true);
    }
}
