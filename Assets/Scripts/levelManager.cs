using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    [Serializable]
    public struct Robots
    {
        public int nb_robot_rouge;
        public int nb_robot_bleu;
        public int nb_robot_vert;
        public int nb_robot_jaune;
    }
    [SerializeField]
    public Robots[] robots;
    public bool[] levelDone;

    public bool spawn = false;

    public int level = -1;

    public TeleportRobots robotManager;

    public IEnumerator infinity;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (level != -1 && level != 11 && SceneManager.GetActiveScene().name == "Game" && !spawn)
        {
            SpawnRobots();
            spawn = true;
        }
        if (level == 11 && SceneManager.GetActiveScene().name == "Game" && !spawn)
        {
            infinity = infiniteLevel();
            StartCoroutine(infinity);
            spawn = true;
        }
    }
    public void stop_infinity()
    {
        StopAllCoroutines();
    }
    void SpawnRobots()
    {
        
        for (int i = 0;i < robots[level].nb_robot_rouge; i++)
        {
            StartCoroutine(robotManager.TpCooldownRouge());
        }

        for (int i = 0; i < robots[level].nb_robot_bleu; i++)
        {
            StartCoroutine(robotManager.TpCooldownBleu());
        }

        for (int i = 0; i < robots[level].nb_robot_vert; i++)
        {
            StartCoroutine(robotManager.TpCooldownVert());
        }

        for (int i = 0; i < robots[level].nb_robot_jaune; i++)
        {
            StartCoroutine(robotManager.TpCooldownJaune());
        }
    }

    public IEnumerator infiniteLevel()
    {
        while (true)
        {
            int robotRandom = UnityEngine.Random.Range(0, 4);
            yield return new WaitForSeconds(3);
            if (robotRandom == 0)
            {
                StartCoroutine(robotManager.TpCooldownRouge());
            }
            if (robotRandom == 1)
            {
                StartCoroutine(robotManager.TpCooldownBleu());
            }
            if (robotRandom == 2)
            {
                StartCoroutine(robotManager.TpCooldownVert());
            }
            if (robotRandom == 3)
            {
                StartCoroutine(robotManager.TpCooldownJaune());
            }
        }
    }
}
