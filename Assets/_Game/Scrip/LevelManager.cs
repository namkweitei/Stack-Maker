using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }
    public int level;
    [SerializeField] private List<GameObject> BlockPrefabs;
    [SerializeField] private GameObject Block;
    [SerializeField] private Transform boxClose;
    [SerializeField] private Transform boxOpen;

    private void Start()
    {
        level = PlayerPrefs.GetInt("Level", 0);
        int random = Random.Range(0, 11);
        GameObject bl = Instantiate(BlockPrefabs[random]);
        bl.transform.SetParent(transform);
        Block = bl;
    }
    public void Win()
    {
        boxClose.gameObject.SetActive(false);
        boxOpen.gameObject.SetActive(true);
    }
}
