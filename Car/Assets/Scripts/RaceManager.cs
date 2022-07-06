using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaceManager : MonoBehaviour   // MiniMap Camera
{
    [SerializeField]
    UIController uiController;

    CarController CarController;
    public List<GameObject> carsOnTrack;  // araba listesini herkese a��k hale getiriyoruz.

    void Awake()
    {
        GameObject playerCar = carsOnTrack[GameState.playerCar]; // ? alt sat�rlar� sor.
        if(CarController != null)
        {
            uiController.HandleShowMiniMap(CarController.miniMapCamera);// araba kontrollerinde tan�mlad�k miniMapCamera y� tan�mlad�k.
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
