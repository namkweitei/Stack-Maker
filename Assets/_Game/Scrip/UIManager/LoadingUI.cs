using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] Image progress;
    private void Start()
    {
        LoadingRun();
    }
    public void LoadingRun()
    {
        progress.fillAmount = 0;
        progress.DOFillAmount(1f, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            UIManager.Instance.OpenUI(GameState.Play);
        });
    }
}
