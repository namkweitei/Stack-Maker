using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Vector3 nextPos;
    [SerializeField] private Dir curDir;
    [SerializeField] private bool isMoving;
    [SerializeField] private GameObject playerModel;
    Vector3 pos;
    [SerializeField] PlayerBlock PlayerBlock;
    private void Start()
    {
        pos = transform.position + GetMoveDir(curDir) + Vector3.up;
    }
    void Update()
    {

        if(curDir == Dir.None)
        {
            isMoving = false;
        }
        if (!isMoving)
        {
            curDir = InputManager.GetCurDir();
            CheckMove(curDir);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextPos) < 0.1f )
                isMoving = false;
            nextPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            
            Vector3 dir = GetMoveDir(curDir);
            if (dir != Vector3.zero)
            {
                dir.Normalize();
                Quaternion targetRotation = Quaternion.LookRotation(dir) * Quaternion.Euler(0f,180f,0f);
                playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, targetRotation, Time.deltaTime * 20);
            }
        }
    }

    void CheckMove(Dir dir)
    {
        if (Physics.Raycast(pos, Vector3.down, out RaycastHit hit, Mathf.Infinity, 1 << 8))
        {
            if (dir == Dir.None )
            {
                isMoving = false;
            }
            nextPos = hit.collider.transform.position;
            pos += GetMoveDir(dir);
        }
        else
        {
            pos = transform.position + GetMoveDir(dir) + Vector3.up;
            isMoving = true;
        }
    }
    

    Vector3 GetMoveDir(Dir dir)
    {
        switch (dir)
        {
            case Dir.Forward: return Vector3.forward;
            case Dir.Back: return Vector3.back;
            case Dir.Right: return Vector3.right;
            case Dir.Left: return Vector3.left;
            case Dir.None: return Vector3.zero;
            default: return Vector3.zero;
        }
    }
}
