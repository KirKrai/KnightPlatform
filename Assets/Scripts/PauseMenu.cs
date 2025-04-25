using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Menu; //������� ����

    public static bool GamePause = false;
    public GameObject pauseMenuUi;//����� �����
    public GameObject SettingMenu;//����� ��������


    public static bool playerAlive = true;


    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f; //��������� ����
        GamePause = true;
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void AgainLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }



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
