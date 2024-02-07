using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{//Менеджер интерфейса

    public GameObject ActionPeasantPanel; //Панель действий и создания крестьян


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

    public void OpenActionPeasantPanel() //Открытие панели Действий крестьян
    {
        ActionPeasantPanel.SetActive(true);
    }
    public void ExitActionPeasantPanel() //Закрытие панели Действий крестьян
    {
        ActionPeasantPanel.SetActive(false);
    }

    public void AddPeasant()
    {
        GameManager.Instance.AddAnt();
    }


}
