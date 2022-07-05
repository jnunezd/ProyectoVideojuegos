using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{

    [SerializeField] public GameObject PauseButtonUi;
    [SerializeField] public GameObject MenuPausaUi;
    // Start is called before the first frame update
    public void Pausa()
    {
        Time.timeScale = 0;
        PauseButtonUi.SetActive(false);
        MenuPausaUi.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1;
        PauseButtonUi.SetActive(true);
        MenuPausaUi.SetActive(false);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        PauseButtonUi.SetActive(true);
        MenuPausaUi.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        PauseButtonUi.SetActive(true);
        MenuPausaUi.SetActive(false);
        SceneManager.LoadScene("Level 1");
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    
}
