using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{//Менеджер интерфейса

    [Header("Панель крестьяне")]
    public GameObject ActionPeasantPanel; //Панель действий и создания крестьян
    public TMP_Text TotalPeasant; //Общее количество крестьян
    public TMP_Text FreePeasant; //Свободные крестьяне
    public TMP_Text numberForFoof; //Отображение назначеных крестьян на источник еды
    public TMP_Text numberOnTheWood; //Отображение назначеных крестьян на источник дерева
    public TMP_Text numberOnStones; //Отображение назначеных крестьян на источник камня

    [Header("Панель ресурсов")]
    public TMP_Text Food; //Отображение еды
    public TMP_Text Wood; //Отображение дерева
    public TMP_Text Stone; //Отображение камня

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
        FreePeasant.text = GameManager.Instance.Peasant.ToString();
        TotalPeasant.text = GameManager.Instance.TotalPesant.ToString();
        numberForFoof.text = GameManager.Instance.ForFood.ToString();
        numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        numberOnStones.text = GameManager.Instance.OnStones.ToString();
    }
    private void Update()
    {
        Food.text = "Еда: " + GameManager.Instance.Food.ToString();
        Wood.text = "Дерево: " + GameManager.Instance.Wood.ToString();
        Stone.text = "Камень: " + GameManager.Instance.Stone.ToString();
    }
    public void UpdateTextPeasant() //Обновление текста во вкладке крестьян
    {
        GameManager.Instance.TotalNumberPeasant();//Вызываем функцию для обновления переменной
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
    public void AddPeasantFood() //Функция добавления крестьян в источник еды
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("Крестьяне закончились");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.ForFood++;
            UpdateTextPeasant();
        }
    }
    public void RedusPeasantFood() //Функция удаления крестьян из источника еды
    {
        if (GameManager.Instance.ForFood == 0)
        {
            Debug.Log("Ниже назначить нельзя");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.ForFood--;
            UpdateTextPeasant();
        }
    }
    public void AddPeasantWood() //Функция добавления крестьян в источник дерева
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("Крестьяне закончились");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.OnTheWood++;
            UpdateTextPeasant();
        }
    }
    public void RedusPeasantWood() //Функция удаления крестьян из источника дерева
    {
        if (GameManager.Instance.OnTheWood == 0)
        {
            Debug.Log("Ниже назначить нельзя");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.OnTheWood--;
            UpdateTextPeasant();
        }
    }
    public void AddPeasantStones() //Функция добавления крестьян в источник камня
    {
        if (GameManager.Instance.Peasant == 0)
        {
            Debug.Log("Крестьяне закончились");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant--;
            GameManager.Instance.OnStones++;
            UpdateTextPeasant();
        }
    }
    public void RedusPeasantStones() //Функция удаления крестьян из источника камня
    {
        if (GameManager.Instance.OnStones == 0)
        {
            Debug.Log("Ниже назначить нельзя");
            UpdateTextPeasant();
        }
        else
        {
            GameManager.Instance.Peasant++;
            GameManager.Instance.OnStones--;
            UpdateTextPeasant();
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
        UpdateTextPeasant();
    }


}
