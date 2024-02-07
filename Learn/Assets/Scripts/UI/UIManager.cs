using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{//�������� ����������

    public GameObject ActionPeasantPanel; //������ �������� � �������� ��������


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

    public void OpenActionPeasantPanel() //�������� ������ �������� ��������
    {
        ActionPeasantPanel.SetActive(true);
    }
    public void ExitActionPeasantPanel() //�������� ������ �������� ��������
    {
        ActionPeasantPanel.SetActive(false);
    }

    public void AddPeasant()
    {
        GameManager.Instance.AddAnt();
    }


}
