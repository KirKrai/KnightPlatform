using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public  int EnemyDamage;
    [SerializeField] public  int EnemyHp;
    private int PrevHP;
    public int EnemyHpMax;
    public Animation animDeath;
    public GameObject Player;
    public Animator anim;

    //звуки врагов
    protected AudioSource _adSource;
    public AudioClip DeathSound;

    protected void setSound(float volume)
    {
        if (volume > 100) volume = 100;
        if (volume < 0) volume = 0;

        _adSource.volume = (100 - volume) / 100;
    }

    private void TakeDamage()
    {
        if(PrevHP > EnemyHp)
        {
            PrevHP = EnemyHp;
            anim.SetTrigger("GetHit");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemyHp = EnemyHpMax;
        PrevHP = EnemyHp;
        _adSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag == "Enemy")
        {
            if (EnemyHp <= 0)
            {
                if (Player.GetComponent<PlayerController>().mpPlayer < Player.GetComponent<PlayerController>().mpPlayerMax)
                {
                    Player.GetComponent<PlayerController>().mpPlayer += 1;
                }
                //анимация смерти
                _adSource.PlayOneShot(DeathSound);
                anim.SetTrigger("isDead");
                Destroy(gameObject);
            }
        }
        if (_adSource != null)
        {
            double dist = Math.Sqrt(Math.Pow(Player.transform.position.x - _adSource.transform.position.x, 2) + Math.Pow(Player.transform.position.y - _adSource.transform.position.y, 2));
            setSound((float)dist * 10);
        }
        TakeDamage();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {

            //анимация смерти
            _adSource.PlayOneShot(DeathSound);
            //gameObject.SetActive(false);
           Destroy(gameObject);

        }

    }
       
    
}
