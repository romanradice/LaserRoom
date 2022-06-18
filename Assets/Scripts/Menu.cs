using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public levelManager levelManager;

    public GameObject menuStart;
    public GameObject menuMode;
    public GameObject menuHistoire;
    public GameObject buttonBack;

    public Image[] levels;



    private int menuID = 1;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level").GetComponent<levelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menuID == 1)
        {
            buttonBack.SetActive(false);
            menuStart.SetActive(true);
            menuMode.SetActive(false);
            menuHistoire.SetActive(false);
        }
        if (menuID == 2)
        {
            buttonBack.SetActive(true);
            menuStart.SetActive(false);
            menuMode.SetActive(true);
            menuHistoire.SetActive(false);
        }
        if (menuID == 3)
        {
            buttonBack.SetActive(true);
            menuStart.SetActive(false);
            menuMode.SetActive(false);
            menuHistoire.SetActive(true);

        }
    }
    public void StartGameInfini()
    {
        levelManager.level = 11;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGameHistoire(int level)
    {
        if (levels[level-1].color == Color.white)
        {
            levelManager.level = level-1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void changeMenuID(int id)
    {
        menuID = id;
        if (menuID == 3)
        {
            levelUnlocked();
        }
    }

    public void back()
    {
        menuID -= 1;
    }

    void levelUnlocked()
    {
        int nb_leveldone = 0;
        for (int i = 0; i < 10; i++)
        {
            if (levelManager.levelDone[i] == true )
            {
                levels[i].color = Color.white;
                nb_leveldone += 1;
            }
            else if (nb_leveldone == i)
            {
                levels[i].color = Color.white;
            }
            else 
            {
                levels[i].color = Color.gray;
                
            }
        }
    }
}
