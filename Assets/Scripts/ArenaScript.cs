using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ArenaScript : MonoBehaviour
{
    public GameObject Player;
    private EnemyBehaviour enemyBehaviour;

    public int AllEnemies = 10; // сколько всего заспавниться мобов
    public int MaxEnemies = 3; // максимальное количество мобов одновременно находящихся на арене
    public int CurentEnemies = 0; // сколько мобов уже было заспавнено

    public GameObject Door; // Дверь арены
    public GameObject Door2; // Дверь арены
    public LayerMask whatIsPlayer; 

    // префабы врагов
    public GameObject EnemyPrefub;
    public GameObject FlyingEnemyPrefub;
    public GameObject ShootingEnemyPrefub;

    // массив для хранения gameobject'ов врагов
    private GameObject[] MobOfArena = new GameObject[3];

    // вероятности появления мобов
    private int[] Probes = new int[3] { 40, 50, 10 };
    private int[] Prob = new int[3] { 0, 0, 0};

    // камеры
 

    // текст
    public GameObject textObject;
    private Text textComponent;

    System.Random r = new System.Random();

    private void SpawnEnemies()
    {
        int rInt = r.Next(0, 100);
        float xPosEnemy = gameObject.transform.position.x + r.Next(-1, 1);
        float yPosEnemy = gameObject.transform.position.y + r.Next(-1, 1);
        float zPosEnemy = gameObject.transform.position.z;

        if (rInt < Prob[0])
        {
            GameObject ArenaMob = Instantiate(EnemyPrefub, new Vector3(xPosEnemy, yPosEnemy, zPosEnemy), Quaternion.identity) as GameObject;
            ArenaMob.name = "ArenaMob";
            MobOfArena[Array.FindIndex(MobOfArena, x => x == null)] = ArenaMob;
            enemyBehaviour = ArenaMob.GetComponent<EnemyBehaviour>();
            enemyBehaviour.angry = true;
            return;
        }
        if (rInt < Prob[1])
        {
            GameObject ArenaMob = Instantiate(FlyingEnemyPrefub, new Vector3(xPosEnemy, yPosEnemy, zPosEnemy), Quaternion.identity) as GameObject;
            ArenaMob.name = "ArenaMob";
            MobOfArena[Array.FindIndex(MobOfArena, x => x == null)] = ArenaMob;
            enemyBehaviour = ArenaMob.GetComponent<EnemyBehaviour>();
            enemyBehaviour.angry = true;
            return;
        }
        if (rInt < Prob[2])
        {
            GameObject ArenaMob = Instantiate(ShootingEnemyPrefub, new Vector3(xPosEnemy, yPosEnemy, zPosEnemy), Quaternion.identity) as GameObject;
            ArenaMob.name = "ArenaMob";
            MobOfArena[Array.FindIndex(MobOfArena, x => x == null)] = ArenaMob;
            enemyBehaviour = ArenaMob.GetComponent<EnemyBehaviour>();
            enemyBehaviour.angry = true;
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Door.SetActive(false);
        Door2.SetActive(false);

        Prob[0] = Probes[0];
        for (int i = 1; i < 3; ++i)
            Prob[i] = Prob[i - 1] + Probes[i];

        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = "Enemies spawn:";
            textObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics2D.OverlapBox(new Vector2(Door.transform.position.x + 2, Door.transform.position.y), new Vector2(1,6), 0, whatIsPlayer))
        {
            Door.SetActive(true);
            Door2.SetActive(true);
            textObject.SetActive(true);
        }

        if (Door.activeSelf)
        {
            if (CurentEnemies < AllEnemies)
            {
                if (Array.FindAll(MobOfArena, x => x != null).Length < MaxEnemies)
                {
                    SpawnEnemies();
                    CurentEnemies++;
                }
            }
            if (Array.FindAll(MobOfArena, x => x == null).Length == MaxEnemies)
            {
                Door.SetActive(false);
                Door2.SetActive(false);
                textObject.SetActive(false);
            } 
        }

       
            textComponent.text = "Enemies spawn:" + (AllEnemies - CurentEnemies).ToString();
        
    }
}
