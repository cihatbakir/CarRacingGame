using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaceManager : MonoBehaviour   // MiniMap Camera
{
    [SerializeField]
    UIController uiController;

    CarController CarController;
    public List<GameObject> carsOnTrack;  // araba listesini herkese açýk hale getiriyoruz.

    void Awake()
    {
        GameObject playerCar = carsOnTrack[GameState.playerCar]; // ? alt satýrlarý sor.
        if(CarController != null)
        {
            uiController.HandleShowMiniMap(CarController.miniMapCamera);// araba kontrollerinde tanýmladýk miniMapCamera yý tanýmladýk.
            CarController.MPH += uiController.HandleShowMPHText;
        }
    }
    void OnDestroy()
    {
        if(CarController != null)
        {
            CarController.MPH -= uiController.HandleShowMPHText;
        }
    }
}
