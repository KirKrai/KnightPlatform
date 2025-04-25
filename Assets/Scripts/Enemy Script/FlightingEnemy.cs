// FlightingEnemy.cs Поведение летающего врага.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class FlightingEnemy : EnemyBehaviour
{    
    //звуки врагов
    public AudioClip IdleSound;
    private bool isAttack = false;

    private IEnumerator SoundPlay(AudioClip SoundToPlay)
    {
        IsSoundPlay = false;
        _adSource.PlayOneShot(SoundToPlay);
        yield return new WaitForSeconds(1);
        IsSoundPlay = true;
    }

    // Атака врага
    public virtual void EnemyAttack()
    {
        Vector3 pos = this.transform.position;
        float MoveX = Player.transform.position.x;
        float MoveY = Player.transform.position.y;

        double dist = Math.Sqrt(Math.Pow(MoveX - pos.x, 2) + Math.Pow(MoveY - pos.y, 2)); 

        if (dist < 0.5f && IsSoundPlay)
        {
            isAttack = true;
            StartCoroutine(SoundPlay(AttackSound));
            isAttack = false;
        }
    }

    // Перемещение врага.
    public override void EnemyMove()
    {
        float MoveX = Player.transform.position.x;
        float MoveY = Player.transform.position.y;

        Vector3 pos = this.transform.position;

        Vector3 Move = new Vector3(MoveX - pos.x, MoveY - pos.y,  0.0f);

        if (Move.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);//поворот
        }
        else if (Move.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);//поворот
        }

        this.transform.position = pos + Move * EnemySpeed * Time.deltaTime;
        if(IsSoundPlay && !isAttack)
            StartCoroutine(SoundPlay(IdleSound));
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemySpeed = 1.3f;
        Player = GameObject.FindGameObjectWithTag("Player");
        _adSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!angry)
            AngerEnemy();
        else
            EnemyMove();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAttack();
        double dist = Math.Sqrt(Math.Pow(Player.transform.position.x - _adSource.transform.position.x, 2) + Math.Pow(Player.transform.position.y - _adSource.transform.position.y, 2));
        setSound((float)dist);
    }
}
