using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    public MenuGame menu;

    private Animator animator;

    private AudioSource audio;
    public AudioClip deadSong;

    public int maxHeal = 1;
    private int heal;
    public bool death = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
        heal = maxHeal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void take_damage()
    {
        death = true;
        audio.PlayOneShot(deadSong);
        menu.changeMenuID(2);
    }

    private void OnParticleCollision(GameObject other)
    {
        take_damage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Win"))
        {
            menu.changeMenuID(3);
        }
    }
}
