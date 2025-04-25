using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float MinX; //начальное положение платформы на оси X
    public float MaxX;//конечное положение платформы на оси X

    public float MinY; //начальное положение платформы на оси Y
    public float MaxY;//конечное положение платформы на оси Y

    public float speed; //скорость движения платформы
    private bool moveRigth = true; //условие движения плаформы вперед или назад
    private bool canMove = true; //условие движения

    public bool isMoveX; //направление движения платформы
   
    

    private void MoveX()
    {
        //диапазон движения
        if (transform.position.x <= MinX)
        {
           
            moveRigth = true;
            

        }
        else if (transform.position.x >= MaxX)
        {
          
            moveRigth = false;
            

        }
        //перемещение от начального до конечного положения
        if (moveRigth && canMove)
        {
            transform.position = new Vector3(transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);

        }
        else if (!moveRigth && canMove)
        {
            transform.position = new Vector3(transform.position.x -speed*Time.deltaTime, transform.position.y, transform.position.z);

        }


    }

    private void MoveY()
    {
        //диапазон движения
        if (transform.position.y <= MinY)
        {
         
            moveRigth = true;
         

        }
        else if (transform.position.y >= MaxY)
        {
           
            moveRigth = false;
          


        }
        //перемещение от начального до конечного положения
        if (moveRigth && canMove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y +speed*Time.deltaTime, transform.position.z);

        }
        else if (!moveRigth && canMove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -speed*Time.deltaTime, transform.position.z);

        }


    }







    // Start is called before the first frame update
    void Start()
    {
        

    }

   
    void FixedUpdate()
    {
        if (isMoveX)
            MoveX();
        else
            MoveY();
    }
    void Update()
    {
       
            
        
    }
}
