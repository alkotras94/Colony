using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{//Менеджер интерфейса

    public GameObject ActionPeasantPanel; //Панель действий и создания крестьян
    //public TMP_Text TotalPeasant; //Общее количество крестьян
    public TMP_Text numberForFoof; //Отображение назначеных крестьян на источник еды
    public TMP_Text numberOnTheWood; //Отображение назначеных крестьян на источник дерева
    public TMP_Text numberOnStones; //Отображение назначеных крестьян на источник камня

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

    public void AddPeasantFood() //Функция добавления крестьян в источник еды
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("Крестьяне закончились");
            numberForFoof.text = GameManager.Instance.ForFood.ToString();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.ForFood++;
            numberForFoof.text = GameManager.Instance.ForFood.ToString();
        }
    }
    public void RedusPeasantFood() //Функция удаления крестьян из источника еды
    {
        if (GameManager.Instance.ForFood == 0)
        {
            Debug.Log("Ниже назначить нельзя");
            numberForFoof.text = GameManager.Instance.ForFood.ToString();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.ForFood--;
            numberForFoof.text = GameManager.Instance.ForFood.ToString();
        }
    }

    public void AddPeasantWood() //Функция добавления крестьян в источник дерева
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("Крестьяне закончились");
            numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.OnTheWood++;
            numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        }
    }
    public void RedusPeasantWood() //Функция удаления крестьян из источника дерева
    {
        if (GameManager.Instance.OnTheWood == 0)
        {
            Debug.Log("Ниже назначить нельзя");
            numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.OnTheWood--;
            numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        }
    }

    public void AddPeasantStones() //Функция добавления крестьян в источник камня
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("Крестьяне закончились");
            numberOnStones.text = GameManager.Instance.OnStones.ToString();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.OnStones++;
            numberOnStones.text = GameManager.Instance.OnStones.ToString();
        }
    }
    public void RedusPeasantStones() //Функция удаления крестьян из источника камня
    {
        if (GameManager.Instance.OnStones == 0)
        {
            Debug.Log("Ниже назначить нельзя");
            numberOnStones.text = GameManager.Instance.OnStones.ToString();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.OnStones--;
            numberOnStones.text = GameManager.Instance.OnStones.ToString();
        }
    }

    public void OpenActionPeasantPanel() //Открытие панели Действий крестьян
    {
        ActionPeasantPanel.SetActive(true);
    }
    public void ExitActionPeasantPanel() //Закрытие панели Действий крестьян
    {
        ActionPeasantPanel.SetActive(false);
    }
    public void AddPeasant() //Добавление новых крестьян
    {
        GameManager.Instance.AddAnt();
    }


}
