// ShootingEnemy.cs Поведение стреляющего врага.

using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShootingEnemy : EnemyBehaviour
{
    public GameObject BulletPrefub;
    private bool isShooting = true;
    public Animator anim;

    // Атака врага.
    public override void EnemyAttack()
    {
        SpawnBullet();
        _adSource.PlayOneShot(AttackSound);
    }

    public void SpawnBullet()
    {
        Vector3 pos = this.transform.position;

        var obj = Instantiate(BulletPrefub, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        var Bullet = obj.GetComponent<BulletScript>();
        
    }

    private IEnumerator ShootingCoroutine()
    {
        isShooting = false;
        EnemyAttack();
        yield return new WaitForSeconds(0.7f);
        anim.SetTrigger("isAttack");
        yield return new WaitForSeconds(0.5f);
        anim.ResetTrigger("isAttack");
        yield return new WaitForSeconds(0.3f);
        isShooting = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemySpeed = 0.0f;
        _adSource = GetComponent<AudioSource>();
        //EnemyAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (!angry)
            AngerEnemy();
        else
            if (isShooting)
                StartCoroutine(ShootingCoroutine());

        double dist = Math.Sqrt(Math.Pow(Player.transform.position.x - _adSource.transform.position.x, 2) + Math.Pow(Player.transform.position.y - _adSource.transform.position.y, 2));
        setSound((float)dist * 10);
    }
}
