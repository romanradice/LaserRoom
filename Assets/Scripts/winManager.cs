using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winManager : MonoBehaviour
{
    private levelManager level;

    bool exit = false;
    public int winTime;
    public float timer;
    public GameObject[] positionsRobots;
    public GameObject exitGameObject;

    public GameObject exitGame;

    void Start()
    {
        level = GameObject.FindGameObjectWithTag("level").GetComponent<levelManager>();
        if (level.level != 11)
        {
            StartCoroutine(winTimer());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (exit == true)
        {
            int caseRandom = Random.Range(0, 63);
            Destroy(exitGame);
            exitGame = Instantiate(exitGameObject, positionsRobots[caseRandom].transform.position, exitGameObject.transform.rotation * Quaternion.Euler(0, 0f, 0f)) as GameObject;
            exit = false;
        }
    }
    public void stop_win()
    {
        StopAllCoroutines();
    }
    public IEnumerator winTimer()
    {
        exit = false;
        for (timer = winTime; timer >= 0; timer -= Time.deltaTime)
        {
            yield return null;
        }
        exit = true;
    }

}
