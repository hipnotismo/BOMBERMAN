using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class LevelCreation : MonoBehaviour
{
    [SerializeField] private string levelTextFile;


    [Header("Prefabs")]
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject romPrefab;
    [SerializeField] private GameObject enemyPrefab;

    private int cant = 3;

    [Header("References")]
    [SerializeField] GameObject playerReference = null;
    [SerializeField] GameObject levelDoorReference = null;
    [SerializeField] GameObject floorReference = null;

    FileStream fileStreamOpen;
    StreamReader streamReader;

    List<string> stringMap;

    List<Vector3> levelDoorPositions;
    int posCounter;
    int doorPos;

    bool floorScale = false; 
    const char wall = 'X';
    const char player = 'P';
    const char enemy = 'E';
    const char nothing = 'N';
    const char romp = 'R';
    const char door = 'D';

    void Awake()
    {
        posCounter = 0;
        fileStreamOpen = File.OpenRead("Assets/Asets/Map text/"+ levelTextFile + ".txt");
        streamReader = new StreamReader(fileStreamOpen);

        stringMap = new List<string>();

        while (!streamReader.EndOfStream)
        {
            stringMap.Add(streamReader.ReadLine());
        }
    }

    void Start()
    {
        float playerFloor = 1f;
        float levelDoorFloor = 0.5f;
        float romFloor = 0.5f;

        for (int i = 0; i < stringMap.Count; i++)
        {
            for (int j = 0; j < stringMap[i].Length; j++)
            {

                if (floorScale)
                {
                    floorReference.transform.localScale = new Vector3(stringMap[i].Length,0, stringMap[i].Length);
                    floorScale = !floorScale;
                }

                switch (stringMap[i][j])
                {
                    case player:                      
                        playerReference.transform.position = new Vector3(j, playerFloor, -i);
                        break;
                    case wall:
                        Instantiate(wallPrefab,new Vector3(j,0,-i), wallPrefab.transform.rotation);
                        break;
                    case romp:
                        Instantiate(romPrefab, new Vector3(j, romFloor, -i), romPrefab.transform.rotation);
                        Debug.Log(i);
                        Debug.Log(j);
                     //   levelDoorPositions[posCounter] =(Vector3 (j,0,i));
                       // posCounter++;
                        break;
                    case enemy:
                        Instantiate(enemyPrefab, new Vector3(j, 0, -i), enemyPrefab.transform.rotation);
                        break;
                    case door:
                        levelDoorReference.transform.position = new Vector3(j, levelDoorFloor, -i);
                        break;
                }
            }
        }
        //doorPos = Random.Range(0, levelDoorPositions.Count);
       // levelDoorReference.transform.position = levelDoorPositions[doorPos];
    }

    void Update()
    {
        
    }
}
