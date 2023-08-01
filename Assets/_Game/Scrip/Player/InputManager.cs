using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir
{
    Left,
    Right,
    Back,
    Forward,
    None
}
public class InputManager : MonoBehaviour
{
    [SerializeField] private Vector2 posMoseDown;
    [SerializeField] private Vector2 posMoseUp;
    [SerializeField] private static Dir currentDir;
    [SerializeField] private Vector2 currentPos;
    private Player player;
    private void Awake()
    {
        currentDir = Dir.None;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();

    }
    private void GetMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posMoseDown = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            posMoseUp = Input.mousePosition;
            currentDir = CheckDir();
        }

    }
    private Dir CheckDir()
    {
        currentPos = posMoseUp - posMoseDown;
        if (currentPos.magnitude < 25f)
        {
            return Dir.None;
        }
        float x = currentPos.x;
        float y = currentPos.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
                return Dir.Right;
            else
                return Dir.Left;
        }
        else
        {
            if (y > 0)
                return Dir.Forward;
            else
                return Dir.Back;
        }

    }
    public static Dir GetCurDir()
    {
        return currentDir;
    }

    public static void ResetCurDir()
    {
        currentDir = Dir.None;
    }
}
