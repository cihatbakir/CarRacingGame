using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField]  // public yapmak istemiyorum ama her yerde kullanmam gerekiyor. Bunu kullanmam lazým.
    Button roamButton;

    [SerializeField]
    Button raceButton;

    [SerializeField]
    Button garageButton;

    [SerializeField]
    Button quitButton;


    void Awake()
    {
        roamButton.onClick.AddListener(HandleRoamButtonClicked);
        raceButton.onClick.AddListener(HandleRaceButtonClicked);
        garageButton.onClick.AddListener(HandleGarageButtonClicked);
        quitButton.onClick.AddListener(HandleQuitButtonClicked);

    }
    void OnDestroy()
    {
        roamButton.onClick.RemoveListener(HandleRoamButtonClicked);
        raceButton.onClick.RemoveListener(HandleRaceButtonClicked);
        garageButton.onClick.RemoveListener(HandleGarageButtonClicked);
        quitButton.onClick.RemoveListener(HandleQuitButtonClicked);
    }
    void HandleRoamButtonClicked()
    {
        GameState.isRaceMode = false;
        SceneManager.LoadScene("SelectATrack");
    }

    void HandleRaceButtonClicked()
    {
        GameState.isRaceMode = true;
        SceneManager.LoadScene("SelectATrack");
    }

    void HandleGarageButtonClicked()
    {
        SceneManager.LoadSceneAsync("Garage");
    }
    void HandleQuitButtonClicked()
    {
        Application.Quit();
    }

}
