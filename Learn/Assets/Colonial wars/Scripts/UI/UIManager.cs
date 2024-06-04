using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{//�������� ����������

    [Header("������ ��������")]
    public TMP_Text Food; //����������� ���
    public TMP_Text Wood; //����������� ������
    public TMP_Text Stone; //����������� �����
    public TMP_Text Gold; //����������� ������

    [Header("������ ���������")]
    public GameObject ActionPeasantPanel; //������ �������� � �������� ��������
    public TMP_Text TotalPeasant; //����� ���������� ��������
    public TMP_Text FreePeasant; //��������� ���������
    public TMP_Text numberForFoof; //����������� ���������� �������� �� �������� ���
    public TMP_Text numberOnTheWood; //����������� ���������� �������� �� �������� ������
    public TMP_Text numberOnStones; //����������� ���������� �������� �� �������� �����

    [Header("������ �������")]
    public BaraksManager BaraksManager; //������ ��� ������
    public GameObject PanelBaraks; //������ �������
    public TMP_Text BarracksCapacity; //����������� �������
    public TMP_Text UnitsCapacity; //���������� ���� ������
    public TMP_Text ArcherCapacity; //���������� ��������
    public TMP_Text SpearmanCapacity; //���������� ����������
    public TMP_Text SwordsmanCapacity; //���������� ��������
    public TMP_Text LevelBaraks; //������� ������� �������
    public TMP_Text CurrentLevelCapacity; //����������� �������� ������
    public TMP_Text NextLevelBaraks; //��������� ������� �������
    public TMP_Text NextCurrentLevelCapacity; //����������� ���������� ������
    public TMP_Text[] PriceLevel; //���� ���������� ������ 0-������, 1-������, 2-���, 3-������
    public TMP_Text NotResoursec; //����������� � �������� ��������

    [Header("������")]
    public Camera Camera; //������
    [Header("������ ����������")]
    public GameObject ButtonPeasant; //������ ��������
    public GameObject ButtonBaraks; //������ �������
    public GameObject ButtonBatle; //������ ���� ���
    public GameObject ButtonFortress; //������ ��������

    public static UIManager Instance { get; set; }
    private void Awake()
    {
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

    private void Start()
    {
        UpdatePanelBaraks();
        UpdateTextPeasant();
    }
    private void Update()
    {
        Food.text = "���: " + GameManager.Instance.Food.ToString();
        Wood.text = "������: " + GameManager.Instance.Wood.ToString();
        Stone.text = "������: " + GameManager.Instance.Stone.ToString();
        Gold.text = "������: " + GameManager.Instance.Gold.ToString();
    }

    //������ � �������
    public void GoToTheBattlefield() //������� �� ���� ���
    {
        Camera.transform.position = new Vector3(3,0,-10);
        ButtonPeasant.SetActive(false);
        ButtonBaraks.SetActive(false);
        ButtonBatle.SetActive(false);
        ButtonFortress.SetActive(true);
    }

    public void GoToTheFortress() //������� � ��������
    {
        Camera.transform.position = new Vector3(0, 0, -10);
        ButtonPeasant.SetActive(true);
        ButtonBaraks.SetActive(true);
        ButtonBatle.SetActive(true);
        ButtonFortress.SetActive(false);
    }

    //������� ��� ������ ��������
    public void UpdateTextPeasant() //���������� ������ �� ������� ��������
    {
        GameManager.Instance.TotalNumberPeasant();//�������� ������� ��� ���������� ����������
        FreePeasant.text = GameManager.Instance.Peasant.ToString();
        TotalPeasant.text = GameManager.Instance.TotalPesant.ToString();
        numberForFoof.text = GameManager.Instance.ForFood.ToString();
        numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        numberOnStones.text = GameManager.Instance.OnStones.ToString();
    }
    public void ConfirmPeasant() //������ ������� � UI � ��������
    {
        GameManager.Instance.AreTheObjectsEqual();
        GameManager.Instance.RemovingObjectsFromTheSheet();
        GameManager.Instance.AddingObjectsToSheets();
    }
    public void AddPeasantFood() //������� ���������� �������� � �������� ���
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("��������� �����������");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.ForFood++;
            UpdateTextPeasant();
        }
    }
    public void RedusPeasantFood() //������� �������� �������� �� ��������� ���
    {
        if (GameManager.Instance.ForFood == 0)
        {
            Debug.Log("���� ��������� ������");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.ForFood--;
            UpdateTextPeasant();
        }
    }
    public void AddPeasantWood() //������� ���������� �������� � �������� ������
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("��������� �����������");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.OnTheWood++;
            UpdateTextPeasant();
        }
    }
    public void RedusPeasantWood() //������� �������� �������� �� ��������� ������
    {
        if (GameManager.Instance.OnTheWood == 0)
        {
            Debug.Log("���� ��������� ������");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.OnTheWood--;
            UpdateTextPeasant();
        }
    }
    public void AddPeasantStones() //������� ���������� �������� � �������� �����
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("��������� �����������");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.OnStones++;
            UpdateTextPeasant();
        }
    }
    public void RedusPeasantStones() //������� �������� �������� �� ��������� �����
    {
        if (GameManager.Instance.OnStones == 0)
        {
            Debug.Log("���� ��������� ������");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.OnStones--;
            UpdateTextPeasant();
        }
    }
    public void OpenActionPeasantPanel() //�������� ������ �������� ��������
    {
        ActionPeasantPanel.SetActive(true);
    }
    public void ExitActionPeasantPanel() //�������� ������ �������� ��������
    {
        ActionPeasantPanel.SetActive(false);
    }
    public void AddPeasant() //���������� ����� ��������
    {
        GameManager.Instance.AddAnt();
        UpdateTextPeasant();
    }

    //������� ��� ������ �������
    public void OpenPanelBaraks() //�������� ������ �������
    {
        PanelBaraks.SetActive(true);
    }
    public void ExitPanelBaraks() //�������� ������ �������
    {
        PanelBaraks.SetActive(false);
    }
    public void UpdatePanelBaraks() //������� ������ � ���������� ������ �� ������� �������
    {
        BarracksCapacity.text = BaraksManager.BarracksCapacity.ToString(); //����������� �������
        UnitsCapacity.text = BaraksManager.UnitsCapacity.ToString(); //���������� ���� ������
        ArcherCapacity.text = BaraksManager.Archer.Count.ToString(); //���������� ��������
        SpearmanCapacity.text = BaraksManager.Spearman.Count.ToString(); //���������� ����������
        SwordsmanCapacity.text = BaraksManager.Swordsman.Count.ToString(); //���������� ��������
        LevelBaraks.text = BaraksManager.LevelBaraks.ToString(); ; //������� ������� �������
        CurrentLevelCapacity.text = BaraksManager.BarracksCapacity.ToString(); //����������� �������� ������
        NextLevelBaraks.text = BaraksManager.NextLevelBaraks.ToString(); //��������� ������� �������
        NextCurrentLevelCapacity.text = BaraksManager.NextBaraksCapacity.ToString(); //����������� ���������� ������
        PriceLevel[0].text = BaraksManager.NextStonePriceLevel.ToString(); //���� ���������� ������ ������
        PriceLevel[1].text = BaraksManager.NextWoodPriceLevel.ToString(); //���� ���������� ������ ������
        PriceLevel[2].text = BaraksManager.NextFoodPriceLevel.ToString(); //���� ���������� ������ ���
        PriceLevel[3].text = BaraksManager.NextGoldPriceLevel.ToString(); //���� ���������� ������ ������
    }
    public void AddArcher() //������ ���������� �������
    {
        BaraksManager.AddArcher();
        UpdatePanelBaraks();
    }
    public void AddSpearman() //������ ���������� ���������
    {
        BaraksManager.AddSpearman();
        UpdatePanelBaraks();
    }
    public void AddSwordsman() //������ ���������� �������
    {
        BaraksManager.AddSwordsman();
        UpdatePanelBaraks();
    }
    public void AddLevelBaraks() //������ ���������� ������ �������
    {
        BaraksManager.AddLevel();
        UpdatePanelBaraks();
    }

    public void NotResorses(string message)
    {
        NotResoursec.text = message;
    }
}
