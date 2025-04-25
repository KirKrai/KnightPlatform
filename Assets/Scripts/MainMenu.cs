using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    

    public GameObject Menu; //главное меню


    public GameObject SettingMenu;//экран настроек

    

    


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

    public void Play()
    {
        SceneManager.LoadScene(1); //первая сцена
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
