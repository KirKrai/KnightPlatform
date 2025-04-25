using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    

    public GameObject Menu; //������� ����


    public GameObject SettingMenu;//����� ��������

    

    


    //������� �������� ���� � ����� ���� ���������
    public void ShowMenuSetting()
    {
        Menu.SetActive(false);
        SettingMenu.SetActive(true);

    }

    //������� ���� ���� � ����� �������� ����
    public void Back()
    {

        SettingMenu.SetActive(false);
        Menu.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1); //������ �����
    }

    //������ ����� �� ����
    public void Exit()
    {
        Application.Quit();//�������� ����������
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }





}
