using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    public void Jugar()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Salir()
    {   
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
