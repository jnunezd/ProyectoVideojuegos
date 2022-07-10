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

    private void goNextLvl(){
        SceneManager.LoadScene(nextLvl);
    }

    public void Reset()
    {
        
    }
   
}
