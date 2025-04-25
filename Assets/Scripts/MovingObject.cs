using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float MinX; //��������� ��������� ��������� �� ��� X
    public float MaxX;//�������� ��������� ��������� �� ��� X

    public float MinY; //��������� ��������� ��������� �� ��� Y
    public float MaxY;//�������� ��������� ��������� �� ��� Y

    public float speed; //�������� �������� ���������
    private bool moveRigth = true; //������� �������� �������� ������ ��� �����
    private bool canMove = true; //������� ��������

    public bool isMoveX; //����������� �������� ���������
   
    

    private void MoveX()
    {
        //�������� ��������
        if (transform.position.x <= MinX)
        {
           
            moveRigth = true;
            

        }
        else if (transform.position.x >= MaxX)
        {
          
            moveRigth = false;
            

        }
        //����������� �� ���������� �� ��������� ���������
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
        //�������� ��������
        if (transform.position.y <= MinY)
        {
         
            moveRigth = true;
         

        }
        else if (transform.position.y >= MaxY)
        {
           
            moveRigth = false;
          


        }
        //����������� �� ���������� �� ��������� ���������
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
