using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Menu; //главное меню

    public static bool GamePause = false;
    public GameObject pauseMenuUi;//экран паузы
    public GameObject SettingMenu;//экран настроек


    public static bool playerAlive = true;


    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f; //остановка игры
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



    //Скрытие главного меню и показ меню настройки
    public void ShowMenuSetting()
    {
        Menu.SetActive(false);
        SettingMenu.SetActive(true);

    }

    //Скрытие всех меню и показ главного меню
    public void Back()
    {

        SettingMenu.SetActive(false);
        Menu.SetActive(true);
    }

    

    //кнопка Выход из игры
    public void Exit()
    {
        Application.Quit();//закрытие приложения
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }

}
