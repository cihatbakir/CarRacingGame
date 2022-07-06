using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour       // Mini Map
{
    [SerializeField]
    // List<RenderTexture> renderTextures;  //eski hali
    RenderTexture renderTexture;

    [SerializeField]
    RawImage miniMapImage;  // minimap in ham g�r�nt�s� 

    [SerializeField]
    TMPro.TextMeshProUGUI mphText; //denetleyici

    [SerializeField]
    TMPro.TextMeshProUGUI timerText;  // zamanl�y�c� oyunda 3 tur olacak her tur i�in s�re eklenecek.

    public float totalTime; // total toplam s�re 


    public void HandleShowMiniMap(Camera miniMapCamera)
    {
        /* miniMapCamera.targetTexture = renderTextures[GameState.leverIndex];     //eski hali
         miniMapImage.texture = renderTextures[GameState.leverIndex]; */
        miniMapCamera.targetTexture = renderTexture;
        miniMapImage.texture = renderTexture;
    
    }

    public void HandleShowMPHText(double mph)
    {
        mphText.text = mph + "MPH";  // mph i �a��rd���m�z k�s�m
    }

    void Update()
    {
        if(!GameState.isRaceMode) // yar�� modunda olup olmad���m�z� kontrol edecek
        {
            return;
        }
        totalTime += Time.deltaTime; // Her hareket karemizi saymas� i�in zaman noktas�n� s�remize eklecez.

        int minutes = (int)totalTime / 60;   // dakika belirtecii
        int seconds = (int)totalTime % 60;   // saniye belirtecii
        timerText.text = string.Format("Total Time: {0} : {1}", minutes.ToString("00"), seconds.ToString("00"));
        // �st sat�rda dakika ve saniye de�erlerinin �al��mas� i�in ge�erli kod blo�u kullan�ld�.
    }
}
