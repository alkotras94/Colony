using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{//�������� ����������

    [Header("������ ���������")]
    public GameObject ActionPeasantPanel; //������ �������� � �������� ��������
    public TMP_Text TotalPeasant; //����� ���������� ��������
    public TMP_Text FreePeasant; //��������� ���������
    public TMP_Text numberForFoof; //����������� ���������� �������� �� �������� ���
    public TMP_Text numberOnTheWood; //����������� ���������� �������� �� �������� ������
    public TMP_Text numberOnStones; //����������� ���������� �������� �� �������� �����

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

    public void UpdateTextPeasant() //���������� ������ �� ������� ��������
    {
        GameManager.Instance.TotalNumberPeasant();//�������� ������� ��� ���������� ����������
        FreePeasant.text = GameManager.Instance.Peasant.ToString();
        TotalPeasant.text = GameManager.Instance.TotalPesant.ToString();
        numberForFoof.text = GameManager.Instance.ForFood.ToString();
        numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        numberOnStones.text = GameManager.Instance.OnStones.ToString();
    }

    public void ConfirmPeasant()
    {
        GameManager.Instance.ChangeTheSourceToFood();
        GameManager.Instance.ChangeTheSourceToWood();
        GameManager.Instance.ChangeTheSourceToStone();
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
            numberOnStones.text = GameManager.Instance.OnStones.ToString();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.OnStones--;
            numberOnStones.text = GameManager.Instance.OnStones.ToString();
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


}
