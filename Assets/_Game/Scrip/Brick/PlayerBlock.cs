using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private Stack<GameObject> standingBlock = new Stack<GameObject>();

    [SerializeField]
    GameObject stackBlockPrefab;

    [SerializeField]
    Transform playerBlock;

    [SerializeField]
    GameObject playerModel;

    [SerializeField]
    Animator animator;
    
    
    private void Awake()
    {
        standingBlock.Push(playerModel);
    }
    private void Start()
    {
        Debug.Log(".");

    }

    private void Update()
    {
        playerModel.transform.position = ModelPos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Edible") )
        {
            Debug.Log("..");
            GameObject go;
            go = Instantiate(stackBlockPrefab, StackPos(), Quaternion.identity, playerBlock);
            go.transform.rotation = Quaternion.Euler(-90f, 0f, -90f);
            standingBlock.Push(go);
        }
        else if (other.CompareTag("Inedible") && standingBlock.Count > 1)
        {
            Destroy(standingBlock.Pop());
            other.gameObject.tag = "Untagged";
            if(standingBlock.Count < 2)
            {
                InputManager.ResetCurDir();
                UIManager.Instance.OpenUI(GameState.Lose);
            }
        }
        else if (other.CompareTag("Win"))
        {
            int length = standingBlock.Count - 1;
            for (int i = 0; i < length; i++)
            {
                Destroy(standingBlock.Pop());
            }

        }else if (other.CompareTag("FinishLine"))
        {
            InputManager.ResetCurDir();
            LevelManager.Instance.Win();
            animator.SetInteger("Play", 2);
            Invoke(nameof(OpenWin), 3f);
        }
    }


    Vector3 ModelPos()
    {
        Vector3 v3 = transform.position + new Vector3(0, (standingBlock.Count-2) * 0.2f, 0);
        return v3;
    }
    Vector3 StackPos()
    {
        Vector3 v3 = transform.position + new Vector3(0, (standingBlock.Count-1) * 0.2f, 0);
        return v3;
    }
    public int CoutBrick()
    {
        return standingBlock.Count;
    }
    protected void OpenWin()
    {
        UIManager.Instance.OpenUI(GameState.Win);
    }
}
