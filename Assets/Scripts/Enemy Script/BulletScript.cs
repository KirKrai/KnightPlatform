using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class BulletScript : MonoBehaviour
{
    //звуки врагов
    private AudioSource _adSource;
    public AudioClip DeathSound;

    public int BulletSpeed = 100;
    public GameObject Player;

    private Rigidbody2D Bullet;

    public Animator anim;

    protected void setSound(float volume)
    {
        if (volume > 100) volume = 100;
        if (volume < 0) volume = 0;

        _adSource.volume = (100 - volume) / 100;
    }

    private void BulletMoving(Vector2 direct)
    {
        float MoveX = direct.x;
        float MoveY = direct.y;

        Vector3 pos = Bullet.transform.position;

        double coeff = Math.Sqrt(Math.Pow(MoveX - pos.x, 2) + Math.Pow(MoveY - pos.y, 2));

        Vector2 Move = new Vector2((MoveX - pos.x) / (float)coeff, (MoveY - pos.y) / (float)coeff);

        if (Move.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);//поворот
        }
        else if (Move.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);//поворот
        }

        Bullet.isKinematic = false;
        Bullet.AddForce(Move * BulletSpeed);
    }

    private IEnumerator BulletBoom()
    {
        anim.SetTrigger("BulletBoom");
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void BulletDeath()
    {
        StartCoroutine(BulletBoom());
        _adSource.PlayOneShot(DeathSound);
    }

    // Start is called before the first frame update
    void Start()
    {
        Bullet = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        _adSource = GetComponent<AudioSource>();

        BulletMoving(Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        double dist = Math.Sqrt(Math.Pow(Player.transform.position.x - _adSource.transform.position.x, 2) + Math.Pow(Player.transform.position.y - _adSource.transform.position.y, 2));
        setSound((float)dist * 10);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") BulletDeath();
        if (other.gameObject.tag == "Ground") BulletDeath();
        if (other.gameObject.tag == "Wall") BulletDeath();

    }
}
