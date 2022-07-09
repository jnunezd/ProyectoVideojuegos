using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;

    public GameObject[] hearts;
    public GameObject John;
    
    // Update is called once per frame
    void Update()
    {
        puntos.text = gameManager.MonedasTotales.ToString();

    }
}
