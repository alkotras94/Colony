using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{//Менеджер интерфейса

    [Header("Панель ресурсов")]
    public TMP_Text Food; //Отображение еды
    public TMP_Text Wood; //Отображение дерева
    public TMP_Text Stone; //Отображение камня
    public TMP_Text Gold; //Отображение золота

    [Header("Панель крестьяне")]
    public GameObject ActionPeasantPanel; //Панель действий и создания крестьян
    public TMP_Text TotalPeasant; //Общее количество крестьян
    public TMP_Text FreePeasant; //Свободные крестьяне
    public TMP_Text numberForFoof; //Отображение назначеных крестьян на источник еды
    public TMP_Text numberOnTheWood; //Отображение назначеных крестьян на источник дерева
    public TMP_Text numberOnStones; //Отображение назначеных крестьян на источник камня

    [Header("Панель казармы")]
    public BaraksManager BaraksManager; //Ссылка для данных
    public GameObject PanelBaraks; //Панель казармы
    public TMP_Text BarracksCapacity; //Вместимость казармы
    public TMP_Text UnitsCapacity; //Количество всех юнитов
    public TMP_Text ArcherCapacity; //Количество лучников
    public TMP_Text SpearmanCapacity; //Количество копейщиков
    public TMP_Text SwordsmanCapacity; //Количество мечников
    public TMP_Text LevelBaraks; //Уровень казармы текущий
    public TMP_Text CurrentLevelCapacity; //Вместимость текущего уровня
    public TMP_Text NextLevelBaraks; //Следующий уровень казармы
    public TMP_Text NextCurrentLevelCapacity; //Вместимость следующего уровня
    public TMP_Text[] PriceLevel; //Цена следующего уровня 0-камень, 1-дерево, 2-еда, 3-золото
    public TMP_Text NotResoursec; //Уведомление о нехватке ресурсов

    [Header("Камера")]
    public Camera Camera; //Камера
    [Header("Кнопки интерфейса")]
    public GameObject ButtonPeasant; //Кнопка крестьян
    public GameObject ButtonBaraks; //Кнопка казармы
    public GameObject ButtonBatle; //Кнопка поле боя
    public GameObject ButtonFortress; //Кнопка крепости

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
        Food.text = "Еда: " + GameManager.Instance.Food.ToString();
        Wood.text = "Дерево: " + GameManager.Instance.Wood.ToString();
        Stone.text = "Камень: " + GameManager.Instance.Stone.ToString();
        Gold.text = "Золото: " + GameManager.Instance.Gold.ToString();
    }

    //Работа с камерой
    public void GoToTheBattlefield() //Перейти на поле боя
    {
        Camera.transform.position = new Vector3(3,0,-10);
        ButtonPeasant.SetActive(false);
        ButtonBaraks.SetActive(false);
        ButtonBatle.SetActive(false);
        ButtonFortress.SetActive(true);
    }

    public void GoToTheFortress() //Перейти к крепости
    {
        Camera.transform.position = new Vector3(0, 0, -10);
        ButtonPeasant.SetActive(true);
        ButtonBaraks.SetActive(true);
        ButtonBatle.SetActive(true);
        ButtonFortress.SetActive(false);
    }

    //Функции для панели крестьян
    public void UpdateTextPeasant() //Обновление текста во вкладке крестьян
    {
        GameManager.Instance.TotalNumberPeasant();//Вызываем функцию для обновления переменной
        FreePeasant.text = GameManager.Instance.Peasant.ToString();
        TotalPeasant.text = GameManager.Instance.TotalPesant.ToString();
        numberForFoof.text = GameManager.Instance.ForFood.ToString();
        numberOnTheWood.text = GameManager.Instance.OnTheWood.ToString();
        numberOnStones.text = GameManager.Instance.OnStones.ToString();
    }
    public void ConfirmPeasant() //Кнопка принять в UI у крестьян
    {
        GameManager.Instance.AreTheObjectsEqual();
        GameManager.Instance.RemovingObjectsFromTheSheet();
        GameManager.Instance.AddingObjectsToSheets();
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

    //Функции для панели казарма
    public void OpenPanelBaraks() //Открытие панели казармы
    {
        PanelBaraks.SetActive(true);
    }
    public void ExitPanelBaraks() //Закрытие панели казармы
    {
        PanelBaraks.SetActive(false);
    }
    public void UpdatePanelBaraks() //Функция вывода и обновления текста во вкладке казарма
    {
        BarracksCapacity.text = BaraksManager.BarracksCapacity.ToString(); //Вместимость казармы
        UnitsCapacity.text = BaraksManager.UnitsCapacity.ToString(); //Количество всех юнитов
        ArcherCapacity.text = BaraksManager.Archer.Count.ToString(); //Количество лучников
        SpearmanCapacity.text = BaraksManager.Spearman.Count.ToString(); //Количество копейщиков
        SwordsmanCapacity.text = BaraksManager.Swordsman.Count.ToString(); //Количество мечников
        LevelBaraks.text = BaraksManager.LevelBaraks.ToString(); ; //Уровень казармы текущий
        CurrentLevelCapacity.text = BaraksManager.BarracksCapacity.ToString(); //Вместимость текущего уровня
        NextLevelBaraks.text = BaraksManager.NextLevelBaraks.ToString(); //Следующий уровень казармы
        NextCurrentLevelCapacity.text = BaraksManager.NextBaraksCapacity.ToString(); //Вместимость следующего уровня
        PriceLevel[0].text = BaraksManager.NextStonePriceLevel.ToString(); //Цена следующего уровня камень
        PriceLevel[1].text = BaraksManager.NextWoodPriceLevel.ToString(); //Цена следующего уровня дерево
        PriceLevel[2].text = BaraksManager.NextFoodPriceLevel.ToString(); //Цена следующего уровня еда
        PriceLevel[3].text = BaraksManager.NextGoldPriceLevel.ToString(); //Цена следующего уровня золото
    }
    public void AddArcher() //Кнопка добавления лучника
    {
        BaraksManager.AddArcher();
        UpdatePanelBaraks();
    }
    public void AddSpearman() //Кнопка добавления копейщика
    {
        BaraksManager.AddSpearman();
        UpdatePanelBaraks();
    }
    public void AddSwordsman() //Кнопка добавления мечника
    {
        BaraksManager.AddSwordsman();
        UpdatePanelBaraks();
    }
    public void AddLevelBaraks() //Кнопка увеличения уровня казармы
    {
        BaraksManager.AddLevel();
        UpdatePanelBaraks();
    }

    public void NotResorses(string message)
    {
        NotResoursec.text = message;
    }
}
