using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaverManager : MonoBehaviour
{


    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;
    public static SaverManager Instance { get; set; }
    private void Awake()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    public void Save()
    {
        YandexGame.savesData.Food = GameManager.Instance.Food;
        YandexGame.savesData.Wood = GameManager.Instance.Wood;
        YandexGame.savesData.Stone = GameManager.Instance.Stone;
        YandexGame.savesData.TotalPesant = GameManager.Instance.TotalPesant;
        YandexGame.savesData.Peasant = GameManager.Instance.Peasant;
        YandexGame.savesData.ForFood = GameManager.Instance.ForFood;
        YandexGame.savesData.OnTheWood = GameManager.Instance.OnTheWood;
        YandexGame.savesData.OnStones = GameManager.Instance.OnStones;

        YandexGame.SaveProgress();
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {
        GameManager.Instance.Food = YandexGame.savesData.Food;
        GameManager.Instance.Wood = YandexGame.savesData.Wood;
        GameManager.Instance.Stone = YandexGame.savesData.Stone;
        GameManager.Instance.TotalPesant = YandexGame.savesData.TotalPesant;
        GameManager.Instance.Peasant = YandexGame.savesData.Peasant;
        GameManager.Instance.ForFood = YandexGame.savesData.ForFood;
        GameManager.Instance.OnTheWood = YandexGame.savesData.OnTheWood;
        GameManager.Instance.OnStones = YandexGame.savesData.OnStones;

    }
}
