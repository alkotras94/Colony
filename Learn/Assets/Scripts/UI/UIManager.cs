using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{//�������� ����������

    public GameObject ActionPeasantPanel; //������ �������� � �������� ��������
    //public TMP_Text TotalPeasant; //����� ���������� ��������
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

    public void AddPeasantFood() //������� ���������� �������� � �������� ���
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("��������� �����������");
            numberForFoof.text = GameManager.Instance.ForFood.ToString();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.ForFood++;
            numberForFoof.text = GameManager.Instance.ForFood.ToString();
        }
    }
    public void RedusPeasantFood() //������� �������� �������� �� ��������� ���
    {
        if (GameManager.Instance.ForFood == 0)
        {
            Debug.Log("���� ��������� ������");
            numberForFoof.text = GameManager.Instance.ForFood.ToString();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.ForFood--;
            numberForFoof.text = GameManager.Instance.ForFood.ToString();
        }
    }

    public void AddPeasantWood() //������� ���������� �������� � �������� ������
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("��������� �����������");
            numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.OnTheWood++;
            numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        }
    }
    public void RedusPeasantWood() //������� �������� �������� �� ��������� ������
    {
        if (GameManager.Instance.OnTheWood == 0)
        {
            Debug.Log("���� ��������� ������");
            numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.OnTheWood--;
            numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        }
    }

    public void AddPeasantStones() //������� ���������� �������� � �������� �����
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("��������� �����������");
            numberOnStones.text = GameManager.Instance.OnStones.ToString();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.OnStones++;
            numberOnStones.text = GameManager.Instance.OnStones.ToString();
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
    }


}
