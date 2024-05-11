using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaraksManager : MonoBehaviour
{//Скрипт управления казармой

    public int UnitsCapacity; //Количество всех юнитов
    public Transform Home; //Замок, его координаты
    public GameObject TemplateArcher; //Префаб лучника
    public GameObject TemplateSpearman; //Префаб копейщика
    public GameObject TemplateSwordsman; //Префаб мечника
    public List<GameObject> Archer; //Лист лучников
    public List<GameObject> Spearman; //Лист копейщиков
    public List<GameObject> Swordsman; //Лист мечников
    [Header("Уровень казармы")]
    public int LevelBaraks; //Уровень казармы текущий
    public int NextLevelBaraks; //Следующий уровень казармы
    public int BarracksCapacity; //Вместимость казармы
    public int NextBaraksCapacity; //Вместимость следующего уровня
    public int[] LevelBarracksCapacity; //Уровни вместимости казармы
    [Header("Цены за уровни")]
    public int[] GoldPriceLevel;
    public int[] WoodPriceLevel;
    public int[] FoodPriceLevel;
    public int[] StonePriceLevel;
    [Header("Цена следующего уровня")]
    public int NextGoldPriceLevel;
    public int NextWoodPriceLevel;
    public int NextFoodPriceLevel;
    public int NextStonePriceLevel;
    [Header("Цена за лучника")]
    public int PriceArcherGold;
    public int PriceArcherWood;
    [Header("Цена за копейщика")]
    public int PriceSpearmanGold;
    public int PriceSpearmanWood;
    [Header("Цена за мечника")]
    public int PriceSwordsmanGold;
    public int PriceSwordsmanWood;


    public void AddArcher() //Создание лучника
    {
        if (GameManager.Instance.Gold >= PriceArcherGold || GameManager.Instance.Wood >= PriceArcherWood)
        {
            GameObject templateArcher = Instantiate(TemplateArcher, Home.position, Quaternion.identity);
            Archer.Add(templateArcher);
            GameManager.Instance.Gold -= PriceArcherGold;
            GameManager.Instance.Wood -= PriceArcherWood;
        }
        TotalNumberUnits();
    }
    public void AddSpearman() //Создание копейщика
    {
        if (GameManager.Instance.Gold >= PriceSpearmanGold || GameManager.Instance.Wood >= PriceSpearmanWood)
        {
            GameObject templateSpearman = Instantiate(TemplateSpearman, Home.position, Quaternion.identity);
            Spearman.Add(templateSpearman);
            GameManager.Instance.Gold -= PriceSpearmanGold;
            GameManager.Instance.Wood -= PriceSpearmanWood;
        }
        TotalNumberUnits();
    }
    public void AddSwordsman() //Создание мечника
    {
        if (GameManager.Instance.Gold >= PriceSwordsmanGold || GameManager.Instance.Wood >= PriceSwordsmanWood)
        {
            GameObject templateSwordsman = Instantiate(TemplateSwordsman, Home.position, Quaternion.identity);
            Spearman.Add(templateSwordsman);
            GameManager.Instance.Gold -= PriceSwordsmanGold;
            GameManager.Instance.Wood -= PriceSwordsmanWood;
        }
        TotalNumberUnits();
    }
    public void AddLevel() //Добавить уровень
    {
        if (GoldPriceLevel[LevelBaraks + 1] >= GameManager.Instance.Gold || WoodPriceLevel[LevelBaraks + 1] >= GameManager.Instance.Wood)
        {
            if (FoodPriceLevel[LevelBaraks + 1] >= GameManager.Instance.Food || StonePriceLevel[LevelBaraks + 1] >= GameManager.Instance.Stone)
            {
                LevelBaraks += 1;
                NextLevelBaraks = LevelBaraks + 1;
                BarracksCapacity = LevelBarracksCapacity[LevelBaraks];
                NextBaraksCapacity = LevelBarracksCapacity[LevelBaraks + 1];
                NextGoldPriceLevel = GoldPriceLevel[LevelBaraks+1];
                NextWoodPriceLevel = WoodPriceLevel[LevelBaraks+1];
                NextFoodPriceLevel = FoodPriceLevel[LevelBaraks+1];
                NextStonePriceLevel = StonePriceLevel[LevelBaraks+1];
                GameManager.Instance.Gold -= GoldPriceLevel[LevelBaraks];
                GameManager.Instance.Wood -= WoodPriceLevel[LevelBaraks];
                GameManager.Instance.Food -= FoodPriceLevel[LevelBaraks];
                GameManager.Instance.Stone -= StonePriceLevel[LevelBaraks];
            }
            else
            {
                Debug.Log("Не хватает ресурсов");
            }
        }
        else
        {
            Debug.Log("Не хватает ресурсов");
        }
    }
    public void TotalNumberUnits() //Общее количество юнитов
    {
        var archer = Archer.Count;
        var spearman = Spearman.Count;
        var swordsman = Swordsman.Count;
        UnitsCapacity = archer + spearman + swordsman;
    }

}
