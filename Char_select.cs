using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Char_select : MonoBehaviour
{

    public string loadLevel;
    public GameObject loadingScreen;

    public Image loading_bar;
    public Text loadingPercent;
    public float fill_loadingBar;

   

    /*private int selectionIndex = 0;

    public List<GameObject> availableShips;


    // Use this for initialization
    void Start()
    {
        
        availableShips = new List<GameObject>();
        foreach (Transform t in transform)
        {
            availableShips.Add(t.gameObject);
        }

        foreach (GameObject ship in availableShips)
        {
            ship.SetActive(false);
        }
        nextShip();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
    }


    public void nextShip()
    {
        availableShips[selectionIndex].SetActive(false);
        selectionIndex++;

        if (selectionIndex >= availableShips.Count)
        {
            selectionIndex = 0;
        }
        availableShips[selectionIndex].SetActive(true);

        GameControl.instance.setShip(availableShips[selectionIndex]);
    }

    public void previousShip()
    {
        availableShips[selectionIndex].SetActive(false);
        selectionIndex--;
        if (selectionIndex < 0)
        {
            selectionIndex = availableShips.Count - 1;
        }

        availableShips[selectionIndex].SetActive(true);

        GameControl.instance.setShip(availableShips[selectionIndex]);
    }*/


    /*private GameObject[] playerObjects;

    public int selectedCharacter = 0;

    public string gameScene = "Character selected scene";

    private string selectedCharacterDataName = "SelectedCharacter";

    private void Start()
    {
        HideAllCharacters();

        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName, 0);

        playerObjects[selectedCharacter].SetActive(true);
    }

    private void HideAllCharacters()
    {
       foreach (GameObject g in playerObjects)
        {
            g.SetActive(false);
        }
    }

    public void SelectLeft()
    {
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = playerObjects.Length - 1;
        }
        playerObjects[selectedCharacter].SetActive(true);
    }

    public void RightLeft()
    {
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == playerObjects.Length)
        {
            selectedCharacter = 0;
        }
        playerObjects[selectedCharacter].SetActive(true);
    }

    public void StartScene()
    {
        PlayerPrefs.SetInt(selectedCharacterDataName, selectedCharacter);
        SceneManager.LoadScene("1scene");
    }*/

    //private GameObject[] characters;
    //private int index;

    public GameObject[] charactersImg;
    public int indexCharImg;


    public GameObject[] scenasImg;
    public int indexScenas;

   //public int moneyGame;

   //MoneySet money;

    private void Start()
    {
        
        //moneyGame = money.moneyAmount;
        //moneyGame = PlayerPrefs.GetInt("MoneyAmounto");
        //moneyGame = money.moneyAmount;
        //moneyGame = PlayerPrefs.GetInt("MoneyAmount", money.moneyAmount);


        //index = PlayerPrefs.GetInt("SelectPlayer");
        //indexCharImg = PlayerPrefs.GetInt("SelectPlayerImg");
        //indexScenas = PlayerPrefs.GetInt("SelectScena");

        //characters = new GameObject[transform.childCount];

        //charactersImg = new GameObject[transform.childCount];

        //scenasImg = new GameObject[transform.childCount];


        /*for (int i = 0; i< transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }

        foreach(GameObject go in characters)
        {
            go.SetActive(false);
        }
        if (characters[index])
        {
            characters[index].SetActive(true);
        }*/




        /* for (int i = 0; i < transform.childCount; i++)
         {
             charactersImg[i] = transform.GetChild(i).gameObject;
         }

         foreach (GameObject go in charactersImg)
         {
             go.SetActive(false);
         }
         if (charactersImg[indexCharImg])
         {
             charactersImg[indexCharImg].SetActive(true);
         }




         for (int i = 0; i < transform.childCount; i++)
         {
             scenasImg[i] = transform.GetChild(i).gameObject;
         }

         foreach (GameObject go in scenasImg)
         {
             go.SetActive(false);
         }
         if (scenasImg[indexScenas])
         {
             scenasImg[indexScenas].SetActive(true);
         }
     }*/



        /*public void SelectLeft()
        {
            characters[index].SetActive(false);
            index--;
            if(index < 0)
            {
                index = characters.Length - 1;
            }
            characters[index].SetActive(true);




        }*/

        /*public void SelectLeftCharImg() {
            charactersImg[indexCharImg].SetActive(false);
            indexCharImg--;
            if (indexCharImg < 0)
            {
                indexCharImg = charactersImg.Length - 1;
            }
            charactersImg[indexCharImg].SetActive(true);
        }

        public void SelectRightCharImg()
        {
            charactersImg[indexCharImg].SetActive(false);
            indexCharImg++;
            if (indexCharImg == charactersImg.Length)
            {
                indexCharImg = 0;
            }
            charactersImg[indexCharImg].SetActive(true);*/

    }

    /* public void RightLeft()
     {
         characters[index].SetActive(false);
         index++;
         if (index == characters.Length)
         {
             index = 0;
         }
         characters[index].SetActive(true);



     }*/



    /*public void SelectLeftScena()
    {
        scenasImg[indexScenas].SetActive(false);
        indexScenas--;
        if (indexScenas < 0)
        {
            indexScenas = scenasImg.Length - 1;
        }
        scenasImg[indexScenas].SetActive(true);
    }

    public void SelectRightScena()
    {
        scenasImg[indexScenas].SetActive(false);
        indexScenas++;
        if (indexScenas == scenasImg.Length)
        {
            indexScenas = 0;
        }
        scenasImg[indexScenas].SetActive(true);
    }*/

    public void NextPlayerImg()
    {
        charactersImg[indexCharImg].SetActive(false);
        indexCharImg = (indexCharImg + 1) % charactersImg.Length;
        charactersImg[indexCharImg].SetActive(true);
    }

    public void PreviousPlayerImg()
    {
        charactersImg[indexCharImg].SetActive(false);
        indexCharImg--;
        if (indexCharImg < 0)
        {
            indexCharImg += charactersImg.Length;
        }
        charactersImg[indexCharImg].SetActive(true);
    }








    public void NextScenaImg()
    {
        scenasImg[indexScenas].SetActive(false);
        indexScenas = (indexScenas + 1) % scenasImg.Length;
        scenasImg[indexScenas].SetActive(true);
    }

    public void PreviousScenaImg()
    {
        scenasImg[indexScenas].SetActive(false);
        indexScenas--;
        if (indexScenas < 0)
        {
            indexScenas += scenasImg.Length;
        }
        scenasImg[indexScenas].SetActive(true);
    }

    public void StartScene()
    {
        //PlayerPrefs.SetInt("SelectPlayer", index);
        SceneManager.LoadScene("1scene");
    }

    public void SelectScene()
    {
        switch (this.gameObject.name)
        {
            case "SceneBtn1":
                
                SceneManager.LoadScene("1scene");
                loadingScreen.SetActive(true);
                

                StartCoroutine(LoadAsync());
                break;

            case "SceneBtn2":
                SceneManager.LoadScene("2scene");
                loadingScreen.SetActive(true);
                

                StartCoroutine(LoadAsync());
                break;

            case "SceneBtn3":
                SceneManager.LoadScene("3scene");
                loadingScreen.SetActive(true);
                

                StartCoroutine(LoadAsync());
                break;

            default:
                break;

        }
       
    }

    public void Load()
    {
        loadingScreen.SetActive(true);
        //SceneManager.LoadScene(loadLevel);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadLevel);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            fill_loadingBar = asyncLoad.progress;
            loading_bar.fillAmount = fill_loadingBar;
            loadingPercent.text = (fill_loadingBar * 100).ToString() + (" %");

            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {

                asyncLoad.allowSceneActivation = true;

            }

            yield return null;


        }
    }














    /*public GameObject pers1;
    public GameObject pers2;
    public GameObject pers3;

    private Vector3 charPosition;
    private Vector3 charOutside;

    private int charInt = 1;

    private SpriteRenderer pers1Ren, pers2Ren, pers3Ren;

    private void Awake()
    {
        charPosition = pers1.transform.position;
        charOutside = pers2.transform.position;

        pers1Ren = pers1.GetComponent<SpriteRenderer>();
        pers2Ren = pers2.GetComponent<SpriteRenderer>();
        pers3Ren = pers3.GetComponent<SpriteRenderer>();
       
    }

    public void Next()
    {
        switch (charInt)
        {
            case 1:
                pers1Ren.enabled = false;
                pers1Ren.transform.position = charOutside;
                pers2Ren.transform.position = charPosition;
                pers2Ren.enabled = true;
                charInt++;
                break;
            case 2:
                pers2Ren.enabled = false;
                pers2Ren.transform.position = charOutside;
                pers3Ren.transform.position = charPosition;
                pers3Ren.enabled = true;
                charInt++;
                break;
            case 3:
                pers3Ren.enabled = false;
                pers3Ren.transform.position = charOutside;
                pers1Ren.transform.position = charPosition;
                pers1Ren.enabled = true;
                charInt++;
                break;

            default:
                break;
        }
    }

    public void Previous()
    {

    }*/
}
