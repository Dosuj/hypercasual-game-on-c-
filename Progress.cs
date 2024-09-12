using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Progress : MonoBehaviour
{
    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
        }
        else
        {
            Destroy(Instance);
        }

    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadData;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            LoadData();
        }
    }

    public int BestScore = 0;

    public void SaveData()
    {
        YandexGame.savesData.BestScoreData = BestScore;
        YandexGame.SaveProgress();
    }

    public void LoadData()
    {
        BestScore = YandexGame.savesData.BestScoreData;
    }
}
