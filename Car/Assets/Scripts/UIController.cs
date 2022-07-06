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
    RawImage miniMapImage;  // minimap in ham görüntüsü 

    [SerializeField]
    TMPro.TextMeshProUGUI mphText; //denetleyici

    [SerializeField]
    TMPro.TextMeshProUGUI timerText;  // zamanlýyýcý oyunda 3 tur olacak her tur için süre eklenecek.

    public float totalTime; // total toplam süre 


    public void HandleShowMiniMap(Camera miniMapCamera)
    {
        /* miniMapCamera.targetTexture = renderTextures[GameState.leverIndex];     //eski hali
         miniMapImage.texture = renderTextures[GameState.leverIndex]; */
        miniMapCamera.targetTexture = renderTexture;
        miniMapImage.texture = renderTexture;
    
    }

    public void HandleShowMPHText(double mph)
    {
        mphText.text = mph + "MPH";  // mph i çaðýrdýðýmýz kýsým
    }

    void Update()
    {
        if(!GameState.isRaceMode) // yarýþ modunda olup olmadýðýmýzý kontrol edecek
        {
            return;
        }
        totalTime += Time.deltaTime; // Her hareket karemizi saymasý için zaman noktasýný süremize eklecez.

        int minutes = (int)totalTime / 60;   // dakika belirtecii
        int seconds = (int)totalTime % 60;   // saniye belirtecii
        timerText.text = string.Format("Total Time: {0} : {1}", minutes.ToString("00"), seconds.ToString("00"));
        // üst satýrda dakika ve saniye deðerlerinin çalýþmasý için geçerli kod bloðu kullanýldý.
    }
}
