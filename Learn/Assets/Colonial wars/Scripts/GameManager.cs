﻿using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{//Контроллер крестьян добавление, удаление крестьян на действия
    [Header("Гейм менеджер")]

    [Tooltip("Ресурсы ягод")] public int Food;
    [Tooltip("Ресурсы дерева")] public int Wood;
    [Tooltip("Ресурсы камня")] public int Stone;
    [Tooltip("Ресурсы золота")] public int Gold;
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
    [Tooltip("Место сбора лучников после создания")] public Transform ColectingArcher;
    [Tooltip("Место сбора копейщиков после создания")] public Transform ColectingSpearman;
    [Tooltip("Место сбора мечников после создания")] public Transform ColectingSwordsman;
    [Tooltip("Место поле боя")] public Transform ColectingFront;

    //Счетчики для ресурсов/крестьян, вспомогательные переменные
    public int TotalPesant; //Общее количество крестьян
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
    private void Start()
    {
        StartSaveAddAnt();
    }
    public void StartSaveAddAnt()//Создание сохраненных крестьян при загрузке игры
    {
        for (int i = 0; i < TotalPesant; i++)
        {
            GameObject templateAnt = Instantiate(_templateAnt, _targetAnt.position, Quaternion.identity);
            _peasant.Add(templateAnt.GetComponent<MovingII>()); ;
        }
        ChangeTheSourceToFood();
        ChangeTheSourceToStone();
        ChangeTheSourceToWood();
    }
    public void AddAnt() // добавление новых крестьян
    {
        GameObject templateAnt = Instantiate(_templateAnt, _targetAnt.position, Quaternion.identity);
        Peasant++;
        _peasant.Add(templateAnt.GetComponent<MovingII>()); ;
    }
    public void TotalNumberPeasant() //Общее количество крестьян
    {
        var peasant = _peasant.Count;
        var peasantFood = _peasantFood.Count;
        var peasantWood = _peasantWood.Count;
        var peasantStone = _peasantStone.Count;
        TotalPesant = peasant + peasantFood + peasantWood + peasantStone;
    }
    public void AreTheObjectsEqual() //Сначало проверяем на равность
    {
        if (ForFood == _peasantFood.Count)
        {
            Debug.Log("С крестьянами еды ничего не делать");
        }
        if (OnStones == _peasantStone.Count)
        {
            Debug.Log("С крестьянами камня ничего не делать");
        }
        if (OnTheWood == _peasantWood.Count)
        {
            Debug.Log("С крестьянами дерева ничего не делать");
        }
    }
    public void RemovingObjectsFromTheSheet() // удаление объектов с листа
    {
        if (_peasantFood.Count > ForFood)
        {
            var peasant = _peasantFood.Count - ForFood;
            RemovePeasant(_peasantFood, peasant);
            Debug.Log("Удалить крестьян с добычи еды в количестве: " + peasant);
        }
        if (_peasantStone.Count > OnStones)
        {
            var peasant = _peasantStone.Count - OnStones;
            RemovePeasant(_peasantStone, peasant);
            Debug.Log("Удалить крестьян с добычи камня в количестве: " + peasant);
        }
        if (_peasantWood.Count > OnTheWood)
        {
            var peasant = _peasantWood.Count - OnTheWood;
            RemovePeasant(_peasantWood, peasant);
            Debug.Log("Удалить крестьян с добычи дерева в количестве: " + peasant);
        }
    }
    public void AddingObjectsToSheets() //Добавление обьектов в лист
    {
        if (_peasantFood.Count < ForFood)
        {
            var peasant = ForFood - _peasantFood.Count;
            AddPeasant(_peasantFood, peasant, FoodSource);
            Debug.Log("Добавить крестьян на добычу еды в количестве: " + peasant);
        }
        if (_peasantStone.Count < OnStones)
        {
            var peasant = OnStones - _peasantStone.Count;
            AddPeasant(_peasantStone, peasant, SheetSource);
            Debug.Log("Добавить крестьян на добычу камня в количестве: " + peasant);
        }
        if (_peasantWood.Count < OnTheWood)
        {
            var peasant = OnTheWood - _peasantWood.Count;
            AddPeasant(_peasantWood, peasant, WoodSource);
            Debug.Log("Добавить крестьян на добычу дерева в количестве: " + peasant);
        }

    }
    public void ChangeTheSourceToFood() //Поменять источник на еду
    {
        if (ForFood == _peasantFood.Count)
        {
            Debug.Log("С крестьянами еды ничего не делать");
        }
        else if (_peasantFood.Count > ForFood)
        {
            var peasant = _peasantFood.Count - ForFood;
            RemovePeasant(_peasantFood, peasant);
            Debug.Log("Удалить крестьян с добычи еды в количестве: " + peasant);
        }
        else if (_peasantFood.Count < ForFood)
        {
            var peasant = ForFood - _peasantFood.Count;
            AddPeasant(_peasantFood, peasant, FoodSource);
            Debug.Log("Добавить крестьян на добычу еды в количестве: " + peasant);
        }
    }
    public void ChangeTheSourceToStone() //Поменять источник на камень
    {
        if (OnStones == _peasantStone.Count)
        {
            Debug.Log("С крестьянами камня ничего не делать");
        }
        else if (_peasantStone.Count > OnStones)
        {
            var peasant = _peasantStone.Count - OnStones;
            RemovePeasant(_peasantStone, peasant);
            Debug.Log("Удалить крестьян с добычи камня в количестве: " + peasant);
        }
        else if (_peasantStone.Count < OnStones)
        {
            var peasant = OnStones - _peasantStone.Count;
            AddPeasant(_peasantStone, peasant, SheetSource);
            Debug.Log("Добавить крестьян на добычу камня в количестве: " + peasant);
        }
    }
    public void ChangeTheSourceToWood() //Поменять источник на дерево
    {
        if (OnTheWood == _peasantWood.Count)
        {
            Debug.Log("С крестьянами дерева ничего не делать");
        }
        else if (_peasantWood.Count > OnTheWood)
        {
            var peasant = _peasantWood.Count - OnTheWood;
            RemovePeasant(_peasantWood, peasant);
            Debug.Log("Удалить крестьян с добычи дерева в количестве: " + peasant);
        }
        else if (_peasantWood.Count < OnTheWood)
        {
            var peasant = OnTheWood - _peasantWood.Count;
            AddPeasant(_peasantWood, peasant, WoodSource);
            Debug.Log("Добавить крестьян на добычу дерева в количестве: " + peasant);
        }
    }
    public void RemovePeasant(List<MovingII> list, int peasant) //метод удаления обьектов с листа
    {
        for (int i = 0; i < peasant; i++)
        {
            list[i].TargetIstochnic = ColectingPeasant;
            _peasant.Add(list[i]);
            _peasant[i].Speed = 0.2f;
        }
        list.RemoveRange(0, peasant);
    }
    public void AddPeasant(List<MovingII> list, int peasant,Transform source) //метод добавления обьектов в лист
    {
        for (int i = 0; i < peasant; i++)
        {
                //_peasant[i].Speed = 0.2f;
                _peasant[i].TargetIstochnic = source;
                list.Add(_peasant[i]);
                list[i].Speed = 0.2f;
        }
        _peasant.RemoveRange(0, peasant);
    }
    public void SpendMoney(int food, int wood, int stone, int gold)
    {
        
    }



}
