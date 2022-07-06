using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    Button resumeButton;

    [SerializeField] 
    Button menuButton;

    [SerializeField]
    Button quitButton;

    [SerializeField] 
    Canvas menuCanvas;

    void Awake()
    {
        resumeButton.onClick.AddListener(HandleResumeButtonClicked);
        menuButton.onClick.AddListener(HandleMenuButtonClicked);
        quitButton.onClick.AddListener(HandleQuitButtonClicked);
    }
    void OnDestroy()
    {
        resumeButton.onClick.RemoveListener(HandleResumeButtonClicked);
        menuButton.onClick.RemoveListener(HandleMenuButtonClicked);
        quitButton.onClick.RemoveListener(HandleQuitButtonClicked);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Track1" || SceneManager.GetActiveScene().name == "Track2");
        // mevcut aktif sahen yi kontrol eder 1 mi 2 mi �eklinde.
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuCanvas.gameObject.SetActive(true); // menu yu a��k b�rak�yoruz 
                Time.timeScale = 0f; // Oyun durdu�unda zaman� durdurur.
            }
        }

        
    }

    void HandleResumeButtonClicked()
    {
        menuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1F;
    }
    void HandleMenuButtonClicked()
    {
        menuCanvas.gameObject.SetActive(false);    
        SceneManager.LoadSceneAsync("MainMenu");
    }

    void HandleQuitButtonClicked()
    {
        Application.Quit(); // ��kma butonu
    }
}
