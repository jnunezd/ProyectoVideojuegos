using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get {return puntosTotales;} }
    private int puntosTotales = 0;


    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log("Puntos totales: " + puntosTotales);
    }

    public void Reset()
    {
        
    }
   
}
