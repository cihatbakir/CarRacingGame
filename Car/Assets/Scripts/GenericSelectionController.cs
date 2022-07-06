using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenericSelectionController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> objects;

    [SerializeField]
    Button forwarButton; // ileri button , ileriye gitmek i�in

    [SerializeField]
    Button backButton;   // geri butonu 

    [SerializeField]
    Button backToMenuButton; // menu ye d�n butonu


    GameObject currentObject;
    int index = 0;


    [SerializeField]
    List<CarStats> carStats = null;  // CarStats dan �ektik


    [SerializeField]
    Image topSpeedUI = null; // speed � null a ba�lad�k.


    [SerializeField]
    Image accelerationUI = null; // H�z� null a ba�lad�k.

    [SerializeField]
    Image handlingUI = null; // Ta��may� null a ba�lad�k.

    [SerializeField]
    bool isCarSelection = false;  // araba se�imini bool i�erisinde false ile ba�lad�k.



    void Awake()
    {
        SetCurrentObject();
        forwarButton.onClick.AddListener(HandleForwardButtonClicked);
        backButton.onClick.AddListener(HandleBackButtonClicked);
        backToMenuButton.onClick.AddListener(HandleBackToMenuButtonClicked);
    }
     void OnDestroy()
    {
        forwarButton.onClick.AddListener(HandleForwardButtonClicked);
        backButton.onClick.AddListener(HandleBackButtonClicked);
        backToMenuButton.onClick.AddListener(HandleBackToMenuButtonClicked);
    }


     void Update()
    {
       if (isCarSelection)   // Araba se�imi 
        {
            currentObject?.transform.Rotate(0, 30 * Time.deltaTime, 0);  // ?. RETURN etmek anlam�nda 
        }
    }
    void HandleForwardButtonClicked()
    {
        index = (index + 1 < objects.Count) ? index + 1 : 0;
        currentObject = objects[index];
        SetCurrentObject();
    }


    void HandleBackButtonClicked()
    {
        index = (index - 1 > -1) ? index - 1 : objects.Count - 1;
        currentObject = objects[index];
        SetCurrentObject();
    }


    void SetCurrentObject()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        currentObject = objects[index];
        currentObject.SetActive(true);



          //CarStats i�in 
        if (isCarSelection)
        {
            GameState.playerCar = index;
            DisplayCarStatsUI();
        }
        else
        {
            GameState.leverIndex = index;
        }
       
        // GameState.leverIndex = index; // yorum sat�r�na alabiliriz.
    }


    void HandleBackToMenuButtonClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    void DisplayCarStatsUI()
    {
        float speedPercent = carStats[index].topSpeed / 100f; // h�z�n� 100 ile b�lmek i�in
        float accelerationPercent = carStats[index].acceleration / 100f;
        float handlingPercent = carStats[index].handling / 100f;

        // vector� mac h�z y�zdesini ayarlayaca��z. 
      
        
        /* topSpeedUI.rectTransform.anchorMax = new Vector2(speedPercent, 1);
         accelerationUI.rectTransform.anchorMax = new Vector2(accelerationPercent, 1);    // burada boyutland�rd���m�zda g�stergenin boyutu b�y�yor.
         handlingUI.rectTransform.anchorMax = new Vector2(handlingPercent, 1); */


        topSpeedUI.rectTransform.anchorMax = new Vector3(speedPercent, 0.5f);
        accelerationUI.rectTransform.anchorMax = new Vector3(accelerationPercent, 0.5f);
        handlingUI.rectTransform.anchorMax = new Vector3(handlingPercent, 0.5f);


        topSpeedUI.rectTransform.right = new Vector3(0, 0, 0);
        accelerationUI.rectTransform.right = new Vector3(0, 0, 0);
        handlingUI.rectTransform.right = new Vector3(0, 0, 0);

    }
}
