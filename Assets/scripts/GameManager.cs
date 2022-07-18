using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int MonedasTotales { get {return monedasTotales;} }
    private int monedasTotales = 0;

    public int nextLvl;


    public void SumarPuntos(int monedasASumar)
    {
        monedasTotales += monedasASumar;
        Debug.Log("Puntos totales: " + monedasTotales);
    }

    public void goNextLvl(){

        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");
        SceneManager.LoadScene(nextLvl);
    }

   
}
