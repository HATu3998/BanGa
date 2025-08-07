using System;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float gridSize = 1;
    private Vector3 SpawnPos;
    private int ChickenCurrent;
    [SerializeField] private GameObject ChickenPretabs;
    [SerializeField] private Transform GridChicken;
    [SerializeField] private GameObject Boss;
    public static Spawner Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        SpawnPos.x += ((gridSize / 2 + (width / 4)));
        SpawnPos.y -= gridSize;
        SpawnPos.z = 0;
        SpawnChicken(Mathf.FloorToInt(height / 2 / gridSize), Mathf.FloorToInt(width / 2 / 1.5f));
    }
    void SpawnChicken(int row, int numberChicken)
    {
        float x = SpawnPos.x;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < numberChicken; j++)
            {
                SpawnPos.x = SpawnPos.x + gridSize;
                GameObject Chicken = Instantiate(ChickenPretabs, SpawnPos, Quaternion.identity);
                Chicken.transform.parent = GridChicken;
                ChickenCurrent++;
            }
            SpawnPos.x = x;
            SpawnPos.y -= gridSize;
        }

        // Update is called once per frame
       
    }
    public void DecreaChicken()
    {
        ChickenCurrent--;
        if(ChickenCurrent <= 0)
        {
            Boss.gameObject.SetActive(true);
        }
    }
}
