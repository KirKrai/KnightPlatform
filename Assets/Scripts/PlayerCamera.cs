using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject PlayerTarget;//игровой объект за которым будет следовать камера
    public float smooth;//скорось передвижения камеры
    public Vector3 offset;//координаты камеры относительно объекта



    void Start()
    {
       
        PlayerTarget = GameObject.FindWithTag("Player");
        //smooth = PlayerTarget.GetComponent<PlayerController>().speed;

    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerTarget.transform.position + offset, Time.deltaTime * smooth);

    }
}



