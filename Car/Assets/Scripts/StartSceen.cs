using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceen : MonoBehaviour
{
    // Ekrana týklayýnca bir sonraki ekrana atýyor bizi
    //kodu Main kamera içerisine yerleþtiriyoruz. Button ile birlikte
    [SerializeField]  // public yapmak istemiyorum ama her yerde kullanmam gerekiyor. Bunu kullanmam lazým.
    Button startButton;      // Button u tanýmladýk  // Canvas tuvall


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
