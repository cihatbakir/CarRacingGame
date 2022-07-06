using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour      // Oyun durumu 
{
    public static int playerCar = 0;
    public static int leverIndex = 0; // seviye indeksi
    public static bool canMove = false;  // hareket edebilir = canMove
    public static bool isRaceMode = false; // yarýþ modu

    public const string car1 = "Car1";
    public const string car2 = "Car2";
    public const string car3 = "Car3";
    public const string car4 = "Car4";
    public const string car5 = "Car5";

     void Awake()
    {
        DontDestroyOnLoad(gameObject);   // nesneyi yok etme 
    }
}
