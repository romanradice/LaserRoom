using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public PlayerHeal player;

    private levelManager level;
    bool timer = false;
    float time = 0;

    public Text text;
    void Start()
    {
        level = GameObject.FindGameObjectWithTag("level").GetComponent<levelManager>();
        if (level.level == 11)
        {
            timer = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            time += Time.deltaTime;
            if (!player.death)
            {
                text.text = System.Math.Round(time, 1).ToString();
            }
            
        }
    }
}
