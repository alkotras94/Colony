using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaraksManager : MonoBehaviour
{//������ ���������� ��������

    public int UnitsCapacity; //���������� ���� ������
    public Transform Home; //�����, ��� ����������
    public GameObject TemplateArcher; //������ �������
    public GameObject TemplateSpearman; //������ ���������
    public GameObject TemplateSwordsman; //������ �������
    public List<GameObject> Archer; //���� ��������
    public List<GameObject> Spearman; //���� ����������
    public List<GameObject> Swordsman; //���� ��������
    [Header("������� �������")]
    public int LevelBaraks; //������� ������� �������
    public int NextLevelBaraks; //��������� ������� �������
    public int BarracksCapacity; //����������� �������
    public int NextBaraksCapacity; //����������� ���������� ������
    public int[] LevelBarracksCapacity; //������ ����������� �������
    [Header("���� �� ������")]
    public int[] GoldPriceLevel;
    public int[] WoodPriceLevel;
    public int[] FoodPriceLevel;
    public int[] StonePriceLevel;
    [Header("���� ���������� ������")]
    public int NextGoldPriceLevel;
    public int NextWoodPriceLevel;
    public int NextFoodPriceLevel;
    public int NextStonePriceLevel;
    [Header("���� �� �������")]
    public int PriceArcherGold;
    public int PriceArcherWood;
    [Header("���� �� ���������")]
    public int PriceSpearmanGold;
    public int PriceSpearmanWood;
    [Header("���� �� �������")]
    public int PriceSwordsmanGold;
    public int PriceSwordsmanWood;


    public void AddArcher() //�������� �������
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
    public void AddSpearman() //�������� ���������
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
    public void AddSwordsman() //�������� �������
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
    public void AddLevel() //�������� �������
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
                Debug.Log("�� ������� ��������");
            }
        }
        else
        {
            Debug.Log("�� ������� ��������");
        }
    }
    public void TotalNumberUnits() //����� ���������� ������
    {
        var archer = Archer.Count;
        var spearman = Spearman.Count;
        var swordsman = Swordsman.Count;
        UnitsCapacity = archer + spearman + swordsman;
    }

}
