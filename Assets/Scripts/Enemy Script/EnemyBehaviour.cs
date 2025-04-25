// EnemyBehaviour.cs Стандартное поведение врага.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyBehaviour : MonoBehaviour
{
    //звуки врагов
    protected AudioSource _adSource;
    public AudioClip AttackSound;

    public GameObject Player;
    public LayerMask whatIsPlayer;

    public float EnemySpeed;
    public float RadiusOfVision = 10.0f;

    public bool angry = false;

    protected bool IsSoundPlay = true;

    [SerializeField] public Rigidbody2D rb;

    protected void setSound(float volume)
    {
        if(volume > 100) volume = 100;
        if(volume < 0) volume = 0;

        _adSource.volume = (100 - volume)/100;
    }

    private IEnumerator SoundPlay()
    {
        IsSoundPlay = false;
        _adSource.PlayOneShot(AttackSound);
        yield return new WaitForSeconds(1);
        IsSoundPlay = true;
    }

    // Атака врага
    public virtual void EnemyAttack()
    {
        Vector3 pos = this.transform.position;
        float MoveX = Player.transform.position.x;
        if (MoveX - pos.x < 0.5f && IsSoundPlay)
        {
            StartCoroutine(SoundPlay());
        }
    }

    // Перемещение врага.
    public virtual void EnemyMove()
    {


        float MoveX = Player.transform.position.x;
        float MoveY = Player.transform.position.y;

        Vector3 pos = this.transform.position;

        Vector3 Move = new Vector3(MoveX - pos.x, 0.0f, 0.0f);

        if (Move.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);//поворот
        }
        else if (Move.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);//поворот
        }

        this.transform.position = pos + Move * EnemySpeed * Time.deltaTime;
    }

    public void AngerEnemy()
    {
        if (Physics2D.OverlapCircle(new Vector2(this.transform.position.x, this.transform.position.y), RadiusOfVision, whatIsPlayer))
        {
            angry = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
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
        if (_adSource != null)
        {
            double dist = Math.Sqrt(Math.Pow(Player.transform.position.x - _adSource.transform.position.x, 2) + Math.Pow(Player.transform.position.y - _adSource.transform.position.y, 2));
            setSound((float)dist * 10);
        }
    }
}
