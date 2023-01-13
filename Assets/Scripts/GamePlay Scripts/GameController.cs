using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]private GameObject finishLine;
    public Color[] colors;
    [HideInInspector]
    public Color hitColor, failColor;

    private int wallsSpawnNumber = 11;

    private float z = 7;

    private bool colorBump;

    private void Awake()
    {
        instance = this;
        GenerateColors();
    }
    void Start()
    {
        SpawnWalls();     
    }
    void GenerateColors()
    {
        hitColor = colors[Random.Range(0, colors.Length)];
        failColor = colors[Random.Range(0, colors.Length)];

        while (hitColor == failColor)
            failColor = colors[Random.Range(0, colors.Length)];

        Ball.SetColor(hitColor);
       
    }

    void SpawnWalls()
    {
        for (int i = 0; i < wallsSpawnNumber; i++)
        {
            GameObject wall;

            if(Random.value <= 0.2 && !colorBump)
            {
                colorBump = true;
                wall = Instantiate(Resources.Load("Colorbump") as GameObject, transform.position, Quaternion.identity);
            }
            else
            {
                wall = Instantiate(Resources.Load("Wall") as GameObject, transform.position, Quaternion.identity);
            }

            wall.transform.SetParent(GameObject.Find("Helix").transform);
            wall.transform.localPosition = new Vector3(0, 0, z);
            float randomRotation = Random.Range(0, 360);
            wall.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, randomRotation));
            z += 7;

            if(i == wallsSpawnNumber-1)
            {
                finishLine.transform.position = new Vector3(0, 0.03f, z*2);
            }
        }
    }
}
