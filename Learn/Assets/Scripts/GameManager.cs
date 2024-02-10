using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Гейм менеджер")]
    [Tooltip("Ресурсы ягод")] [SerializeField] private int _food;
    [Tooltip("Ресурсы дерева")] [SerializeField] private int _wood;
    [Tooltip("Ресурсы камня")] [SerializeField] private int _stones;
    [Tooltip("Лист с крестьянами без работы")] [SerializeField] private List<MovingII> _peasant;
    [Tooltip("Лист с крестьянами, с путем к камню")] [SerializeField] private List<MovingII> _peasantStone = new List<MovingII>();
    [Tooltip("Лист с крестьянами, с путем к дереву")] [SerializeField] private List<MovingII> _peasantWood = new List<MovingII>();
    [Tooltip("Лист с крестьянами, с путем к еде")] [SerializeField] private List<MovingII> _peasantFood = new List<MovingII>();
    [Tooltip("Шаблон с крестьянами")] [SerializeField] private GameObject _templateAnt; 
    [Tooltip("Место создания крестьян")] [SerializeField] private Transform _targetAnt;
    [Tooltip("Координаты склада")] public Transform Home; // Склад, дом
    [Tooltip("Место сбора после создания")] public Transform ColectingPeasant; // Место сбора после создания крестьян и не работающих крестьян
    [Tooltip("Источник еды")] public Transform FoodSource; // Источник еды
    [Tooltip("Источник камня")] public Transform SheetSource; // Источник камня
    [Tooltip("Источник дерева")] public Transform WoodSource; // Источник дерева

    //Счетчики для ресурсов, вспомогательные переменные
    public int Peasant; //Вспомогательная переменная хранящая значения свободных крестьян
    public int ForFood; //На еду
    public int OnTheWood; //Кто пойдет на дерево
    public int OnStones; //Кто пойдет на камень

    public static GameManager Instance { get; set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void AddAnt() // добавление новых крестьян
    {
        Peasant++;
        GameObject templateAnt = Instantiate(_templateAnt, _targetAnt.position, Quaternion.identity);
        _peasant.Add(templateAnt.GetComponent<MovingII>()); ;
    }

    public void ChangeTheSourceToFood() //Поменять источник на еду
    {
        for (int i = 0; i < ForFood; i++)
        {
            _peasant[i].Speed = 0.2f;
            _peasant[i].TargetIstochnic = FoodSource;
            _peasantFood.Add(_peasant[i]);
        }
        _peasant.RemoveRange(0, ForFood);
    }
    public void ChangeTheSourceToStone() //Поменять источник на камень
    {
        for (int i = 0; i < OnStones; i++)
        {
            _peasant[i].Speed = 0.2f;
            _peasant[i].TargetIstochnic = SheetSource;
            _peasantStone.Add(_peasant[i]);
        }
        _peasant.RemoveRange(0, OnStones);
    }

    public void ChangeTheSourceToWood() //Поменять источник на дерево
    {
        for (int i = 0; i < OnTheWood; i++)
        {
            _peasant[i].Speed = 0.2f;
            _peasant[i].TargetIstochnic = WoodSource;
            _peasantWood.Add(_peasant[i]);
        }
        _peasant.RemoveRange(0, OnTheWood);
    }

}
