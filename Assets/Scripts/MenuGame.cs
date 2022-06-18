using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{
    private levelManager level;
    private TeleportRobots robotManager;
    public winManager win;
    public PlayerMovement player;

    public GameObject menuDeath;
    public GameObject menuWin;

    private int menuID = 1;
    // Start is called before the first frame update
    void Start()
    {
        robotManager = GameObject.FindGameObjectWithTag("TeleportRobots").GetComponent<TeleportRobots>();
        level = GameObject.FindGameObjectWithTag("level").GetComponent<levelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menuID == 1)
        {
            menuDeath.SetActive(false);
            menuWin.SetActive(false);
        }

        if (menuID != 1)
        {
            level.stop_infinity();
            player.boxcollider.enabled = false;
            player.rigibody.constraints = RigidbodyConstraints.FreezeAll;
            win.stop_win();
            win.timer = win.winTime;
            Destroy(win.exitGame);
            robotManager.stop_spawn();
        }

        if (menuID == 2)
        {
            menuDeath.SetActive(true);
            menuWin.SetActive(false);

        }
        if (menuID == 3)
        {
            level.levelDone[level.level] = true;
            menuDeath.SetActive(false);
            menuWin.SetActive(true);

        }
    }

    public void Home()
    {
        level.spawn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void restart()
    {
        menuID = 1;
        level.spawn = false;
        StartCoroutine(win.winTimer());
        player.rigibody.constraints = RigidbodyConstraints.FreezeRotation;
        player.boxcollider.enabled = true;

        Application.LoadLevel(Application.loadedLevel);
    }

    public void next_level()
    {
        if (level.level != 9)
        {
            level.level += 1;
        }
        restart();
    }

    public void changeMenuID(int id)
    {
        menuID = id;
    }
}
