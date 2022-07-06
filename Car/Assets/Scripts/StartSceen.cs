using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceen : MonoBehaviour
{
    // Ekrana t�klay�nca bir sonraki ekrana at�yor bizi
    //kodu Main kamera i�erisine yerle�tiriyoruz. Button ile birlikte
    [SerializeField]  // public yapmak istemiyorum ama her yerde kullanmam gerekiyor. Bunu kullanmam laz�m.
    Button startButton;      // Button u tan�mlad�k  // Canvas tuvall


    void Awake()
    {
        startButton.onClick.AddListener(LoadMainMenu);
    }
    void OnDestroy()
    {
        startButton.onClick.RemoveListener(LoadMainMenu);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
