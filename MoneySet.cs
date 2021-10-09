using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Purchasing;
using System;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class MoneySet : MonoBehaviour
{
    //ads
    public int adsoff = 0;
    public GameObject adsOffObjMax;
    public GameObject adsOffObjOscar;
    public GameObject adsOffObjVlad;

    public static MoneySet S;

    public int moneyAmount = 300;
    public int likeAmount = 50;
    //int isRifleSold;

    //private Transform Player;

    public Text moneyAmountText;
    public Text likeAmountText;
    public Text moneyShopText;
    public Text moneyShopTextOscar;
    public Text moneyShopTextVlad;
    public Text moneyChoseSceneText;

    public Text moneyMaxText;
    public Text moneyOscarText;
    public Text moneyVladText;

   

    public GameObject byOscarBtn;
    public GameObject byVladBtn;
    public GameObject chooseOscar;
    public GameObject chooseVlad;
    private int oscarBought = 0;
    private int vladBought = 0;   
    public Image oscarImg;
    public Image vladImg;
    public Sprite oscarSpriteOn;    
    public Sprite vladSpriteOn;

    public GameObject byScena2Btn;
    public GameObject byScena3Btn;
    public GameObject chooseScena2;
    public GameObject chooseScena3;
    private int scena2BounghtOrGet = 0;
    private int scena3BounghtOrGet = 0;
    public Image scena2Img;
    public Image scena3Img;
    public Sprite scena2SpriteOn;
    public Sprite scena3SpriteOn;

    private int followersMax;
    private int followersOscar;
    private int followersVlad;




    private int maxFly;
    public GameObject maxFlyObj;
    public Sprite maxFlyOff;

    //private int maxLaska;
    //private int maxPanda;
    private int oscarFly;
    public GameObject oscarFlyObj;
    public Sprite oscarFlyOff;

    private int oscarLaska;
    public GameObject oscarLaskaObj;
    public Sprite oscarLaskaOff;

    //private int oscarPanda;
    private int vladFly;
    public GameObject vladFlyObj;
    private int vladLaska;
    public GameObject vladLaskaObj;
    private int vladPanda;
    public GameObject vladPandaObj;
    public Sprite vladPAndaOff;
    public GameObject[] presentsBtns;
    //public Text riflePrice;15

    

    public Button BuyLikeButton;


    
    public int randomNumber;
    //public int randomNumberLike;

    public GameObject[] moneyImg;
    //public GameObject[] likeImg;
    public GameObject moneyImgReward;
    private float countDown;
    //private float countDownLike;



    private void Start()
    {
        followersMax = PlayerPrefs.GetInt("WinFollowers");

        oscarBought = PlayerPrefs.GetInt("OscarBought");
        vladBought = PlayerPrefs.GetInt("VladBought");

        scena2BounghtOrGet = PlayerPrefs.GetInt("BoughtScena2");
        scena3BounghtOrGet = PlayerPrefs.GetInt("BoughtScena3");

        maxFly = PlayerPrefs.GetInt("MaxBoughtFly");
        oscarFly = PlayerPrefs.GetInt("OscarBoughtFly");
        oscarLaska = PlayerPrefs.GetInt("OscarBoughtLaska");
        vladFly = PlayerPrefs.GetInt("VladBoughtFly");
        vladLaska = PlayerPrefs.GetInt("VladBoughtLaska");
        vladPanda = PlayerPrefs.GetInt("VladBoughtPanda");

        if(followersMax == 0)
        {
            moneyAmount = 300;
            likeAmount = 50;
            PlayerPrefs.SetInt("MoneyAmountp", moneyAmount);
            PlayerPrefs.SetInt("LikeAmount", likeAmount);
        }
        else
        {
            moneyAmount = PlayerPrefs.GetInt("MoneyAmountp");
            likeAmount = PlayerPrefs.GetInt("LikeAmount");
        }

        
        

        //для теста
       // moneyAmount += 500;
        

        S = this;

        ChackMaxFlyBought();
        ChechScenas();

        adsoff = PlayerPrefs.GetInt("AdsOff");

        

    }

   

    private void Update()
    {
        

        moneyAmountText.text = moneyAmount.ToString();
        likeAmountText.text = likeAmount.ToString();
        moneyShopText.text = moneyAmount.ToString();
        moneyShopTextOscar.text = moneyAmount.ToString();
        moneyShopTextVlad.text = moneyAmount.ToString();
        moneyChoseSceneText.text = moneyAmount.ToString();

        moneyMaxText.text = moneyAmount.ToString();
        moneyOscarText.text = moneyAmount.ToString();
        moneyVladText.text = moneyAmount.ToString();

        PlayerPrefs.SetInt("MoneyAmountp", moneyAmount);
        PlayerPrefs.SetInt("LikeAmount", likeAmount);

        ChackByOscar();
        ChackByVlad();
        CheckByNoAds();

        /*dayInRow = PlayerPrefs.GetInt("dailyBonus");
        if (dayInRow >= 1)
        {
            Debug.Log("Courytine start");
            StartCoroutine(StartBounusDaily());
        }*/
    }
    private void CheckByNoAds()
    {
        if(adsoff == 1)
        {
            adsOffObjMax.GetComponent<Button>().interactable = false;
            adsOffObjOscar.GetComponent<Button>().interactable = false;
            adsOffObjVlad.GetComponent<Button>().interactable = false;
        }
        else
        {
            adsOffObjMax.GetComponent<Button>().interactable = true;
            adsOffObjOscar.GetComponent<Button>().interactable = true;
            adsOffObjVlad.GetComponent<Button>().interactable = true;
        }
    }

    public void buyAdsOff()
    {
        adsoff = 1;
        PlayerPrefs.SetInt("AdsOff", adsoff);

        adsOffObjMax.GetComponent<Button>().interactable = false;
        adsOffObjOscar.GetComponent<Button>().interactable = false;
        adsOffObjVlad.GetComponent<Button>().interactable = false;
    }

    public void buyLike()
    {
        
        if(moneyAmount>= 300)
        {
            moneyAmount -= 300;
            likeAmount += 100;

            
        }
        
        
    } 

   
    public void maxBuyFly()
    {
        if (moneyAmount >= 1000 && maxFly == 0)
        {
            moneyAmount -= 1000;
            maxFly = 1;
            PlayerPrefs.SetInt("MaxBoughtFly", maxFly);
            maxFlyObj.GetComponent<Image>().sprite = maxFlyOff;
            maxFlyObj.GetComponent<Button>().interactable = false;

        }      
    }

    private void ChackMaxFlyBought()
    {
        if(maxFly == 1)
        {
            maxFlyObj.GetComponent<Image>().sprite = maxFlyOff;
            maxFlyObj.GetComponent<Button>().interactable = false;
        }

        if(oscarFly == 1)
        {
            oscarFlyObj.GetComponent<Image>().sprite = oscarFlyOff;
            oscarFlyObj.GetComponent<Button>().interactable = false;
        }

        if(oscarLaska == 11)
        {
            oscarLaskaObj.GetComponent<Image>().sprite = oscarLaskaOff;
            oscarLaskaObj.GetComponent<Button>().interactable = false;
        }

        if(vladFly == 1)
        {
            vladFlyObj.GetComponent<Image>().sprite = oscarFlyOff;
            vladFlyObj.GetComponent<Button>().interactable = false;
        }

        if(vladLaska == 11)
        {
            vladLaskaObj.GetComponent<Image>().sprite = oscarLaskaOff;
            vladLaskaObj.GetComponent<Button>().interactable = false;
        }

        if(vladPanda == 31)
        {
            vladPandaObj.GetComponent<Image>().sprite = vladPAndaOff;
            vladPandaObj.GetComponent<Button>().interactable = false;
        }
    }


   /* public void maxBuyLaska()
    {
        if (moneyAmount >= 2000)
        {
            moneyAmount -= 2000;
            maxLaska = 11;
            PlayerPrefs.SetInt("MaxBoughtLaska", maxLaska);
        }
    }
    public void maxBuyPanda()
    {
        if (moneyAmount >= 3000)
        {
            moneyAmount -= 3000;
            maxPanda = 31;
            PlayerPrefs.SetInt("MaxBoughtPanda", maxPanda);
        }
    }*/
    public void buyPresent()
    {
        if (moneyAmount >= 50)
        {
            moneyAmount -= 50;
            RandomPresent();
        }
    }
    public void oskarBuyFly()
    {
        if (moneyAmount >= 1000 && oscarFly == 0)
        {
            moneyAmount -= 1000;
            oscarFly = 1;
            PlayerPrefs.SetInt("OscarBoughtFly", oscarFly);           
            oscarFlyObj.GetComponent<Image>().sprite = oscarFlyOff;
            oscarFlyObj.GetComponent<Button>().interactable = false;

        }
    }
    public void oskarBuyLaska()
    {
        if (moneyAmount >= 2000 && oscarLaska == 0) 
        {
            moneyAmount -= 2000;
            oscarLaska = 11;
            PlayerPrefs.SetInt("OscarBoughtLaska", oscarLaska);
            oscarLaskaObj.GetComponent<Image>().sprite = oscarLaskaOff;
            oscarLaskaObj.GetComponent<Button>().interactable = false;
        }
    }
    /*public void oskarBuyPanda()
    {
        if (moneyAmount >= 3000)
        {
            moneyAmount -= 3000;
            oscarPanda = 31;
            PlayerPrefs.SetInt("OscarBoughtPanda", oscarPanda);
        }
    }*/
    public void vladBuyFly()
    {
        if (moneyAmount >= 1000 && vladFly == 0)
        {
            moneyAmount -= 1000;
            vladFly = 1;
            PlayerPrefs.SetInt("VladBoughtFly", vladFly);
            vladFlyObj.GetComponent<Image>().sprite = oscarFlyOff;
            vladFlyObj.GetComponent<Button>().interactable = false;
        }
    }
    public void vladBuyLaska()
    {
        if (moneyAmount >= 2000 && vladLaska == 0)
        {
            moneyAmount -= 2000;
            vladLaska = 11;
            PlayerPrefs.SetInt("VladBoughtLaska", vladLaska);
            vladLaskaObj.GetComponent<Image>().sprite = oscarLaskaOff;
            vladLaskaObj.GetComponent<Button>().interactable = false;
        }
    }
    public void vladBuyPanda()
    {
        if (moneyAmount >= 3000 && vladPanda == 0)
        {
            moneyAmount -= 3000;
            vladPanda = 31;
            PlayerPrefs.SetInt("VladBoughtPanda", vladPanda);
            vladPandaObj.GetComponent<Image>().sprite = vladPAndaOff;
            vladPandaObj.GetComponent<Button>().interactable = false;
        }
    }
    public void byUpgrate()
    {
        if (moneyAmount >= 50)
        {
            moneyAmount -= 50;
        }
    }

    public void byOscar()
    {
        if(moneyAmount >= 1000)
        {
            moneyAmount -= 1000;
            byOscarBtn.SetActive(false);
            chooseOscar.SetActive(true);
            oscarImg.sprite = oscarSpriteOn;
            oscarBought = 1;
            PlayerPrefs.SetInt("OscarBought", oscarBought);
        }
    }

    public void ChackByOscar()
    {
        if(oscarBought == 1)
        {
            byOscarBtn.SetActive(false);
            chooseOscar.SetActive(true);
            oscarImg.sprite = oscarSpriteOn;
        }
        else
        {
            byOscarBtn.SetActive(true);
            chooseOscar.SetActive(false);
        }
    }

    public void byVlad()
    {
        if (moneyAmount >= 2000)
        {
            moneyAmount -= 2000;
            byVladBtn.SetActive(false);
            chooseVlad.SetActive(true);
            vladImg.sprite = vladSpriteOn;
            vladBought = 1;
            PlayerPrefs.SetInt("VladBought", vladBought);
        }
    }

    public void ChackByVlad()
    {
        if (vladBought == 1)
        {
            byVladBtn.SetActive(false);
            chooseVlad.SetActive(true);
            vladImg.sprite = vladSpriteOn;
        }
        else
        {
            byVladBtn.SetActive(true);
            chooseVlad.SetActive(false);
        }
    }

    public void byScena2()
    {
        if (moneyAmount >= 2000)
        {
            moneyAmount -= 2000;
            byScena2Btn.SetActive(false);
            chooseScena2.SetActive(true);
            scena2Img.sprite = scena2SpriteOn;
            scena2BounghtOrGet = 1;
            PlayerPrefs.SetInt("BoughtScena2", scena2BounghtOrGet);
        }
    }

    public void byScena3()
    {
        if (moneyAmount >= 3000)
        {
            moneyAmount -= 3000;
            byScena3Btn.SetActive(false);
            chooseScena3.SetActive(true);
            scena3Img.sprite = scena3SpriteOn;
            scena3BounghtOrGet = 1;
            PlayerPrefs.SetInt("BoughtScena3", scena3BounghtOrGet);
        }
    }

    public void buyRifle()
    {
        moneyAmount -= 5;
        PlayerPrefs.SetInt("IsRifleSold", 1);
        //riflePrice.text = "Sold!";
        BuyLikeButton.gameObject.SetActive(false);
    }

    public void goToScene1()
    {
        //PlayerPrefs.SetInt("MoneyAmountp", moneyAmount);
        //PlayerPrefs.SetInt("LikeAmount", likeAmount);
        SceneManager.LoadScene("1scene");
    }

    public void RewardAdsBonus()
    {
        moneyAmount += 20;
        
            
    }
    public void RewardImgMoney()
    {
        StartCoroutine(StartRewardCarutine());
    }

    public void OnPurchaseComplete(Product product)
    {
        switch (product.definition.id)
        {
            case "cyb100coin":
                {
                    addCoins(100);
                }
                break;
            case "cyb1000coin":
                {
                    addCoins(1000);
                }
                break;
            case "cyb5000coin":
                {
                    addCoins(5000);
                }
                break;
           
            
        }
    }

    public void addCoins(int amount)
    {
        moneyAmount += amount;
        
    }

    public void RandomPresent()
    {
        
        StartCoroutine(StartCounterMoney());
        StartCoroutine(StartPresentBtnsOff());

    }

    private IEnumerator StartPresentBtnsOff()
    {
        countDown = 3f;
        for(int i=0; i<3000; i++)
        {
            while(countDown >= 0)
            {
                presentsBtns[0].SetActive(false);
                presentsBtns[1].SetActive(false);
                presentsBtns[2].SetActive(false);
                presentsBtns[3].SetActive(false);
                presentsBtns[4].SetActive(false);
                presentsBtns[5].SetActive(false);
                presentsBtns[6].SetActive(false);
                presentsBtns[7].SetActive(false);
                presentsBtns[8].SetActive(false);
                presentsBtns[9].SetActive(false);
                presentsBtns[10].SetActive(false);
                presentsBtns[11].SetActive(false);
                yield return null;
            }
            presentsBtns[0].SetActive(true);
            presentsBtns[1].SetActive(true);
            presentsBtns[2].SetActive(true);
            presentsBtns[3].SetActive(true);
            presentsBtns[4].SetActive(true);
            presentsBtns[5].SetActive(true);
            presentsBtns[6].SetActive(true);
            presentsBtns[7].SetActive(true);
            presentsBtns[8].SetActive(true);
            presentsBtns[9].SetActive(true);
            presentsBtns[10].SetActive(true);
            presentsBtns[11].SetActive(true);
        }
    }

   




    private IEnumerator StartCounterMoney()
    {
        countDown = 1.5f;
        randomNumber = Random.Range(0, 6);

        if (randomNumber == 0)
            moneyAmount += 25;
        else if (randomNumber == 1)
            moneyAmount += 50;
        else if (randomNumber == 2)
            moneyAmount += 75;
        else if (randomNumber == 3)
            likeAmount += 10;
        else if (randomNumber == 4)
            likeAmount += 20;
        else
            likeAmount += 30;


        for (int i = 0; i < 1500; i++)
        {
            while (countDown >= 0)
            {
                moneyImg[randomNumber].SetActive(true);

                countDown -= Time.smoothDeltaTime;
                yield return null;
            }
            moneyImg[randomNumber].SetActive(false);
        }
    }
    private IEnumerator StartRewardCarutine()
    {
        countDown = 2.5f;
        for(int i=0; i<2500; i++)
        {
            while (countDown >= 0)
            {
                moneyImgReward.SetActive(true);
                countDown -= Time.smoothDeltaTime;
                yield return null;
            }
            moneyImgReward.SetActive(false);
        }
    }
    
    private void ChechScenas()
    {
        if (followersMax >= 1000000 || followersOscar >= 1000000 || followersVlad >= 1000000 || scena2BounghtOrGet == 1)
        {
            chooseScena2.SetActive(true);
            scena2Img.sprite = scena2SpriteOn;
            scena2BounghtOrGet = 1;
            byScena2Btn.SetActive(false);
            PlayerPrefs.SetInt("BoughtScena2", scena2BounghtOrGet);
        }
        else
        {
            chooseScena2.SetActive(false);
            //scena2Img.sprite = scena2off;
        }


        if (followersMax >= 1500000 || followersOscar >= 1500000 || followersVlad >= 1500000 || scena3BounghtOrGet == 1)
        {
            chooseScena3.SetActive(true);
            scena3Img.sprite = scena3SpriteOn;
            scena3BounghtOrGet = 1;
            byScena3Btn.SetActive(false);
            PlayerPrefs.SetInt("BoughtScena3", scena3BounghtOrGet);
        }
        else
        {
            chooseScena3.SetActive(false);
            //scena3Img.sprite = scena3off;
        }


    }

    public void AddRewardPlus30Gold()
    {
        moneyAmount += 30;
    }
    public void AddRewardPlus60Gold()
    {
        moneyAmount += 60;
    }
    public void AddRewardPlus100Gold()
    {
        moneyAmount += 100;
    }
    public void AddRewardPlus150Gold()
    {
        moneyAmount += 150;
    }
    public void AddRewardPlus200Gold()
    {
        moneyAmount += 200;
    }
    public void AddRewardPlus25Like()
    {
        likeAmount += 25;
    }
    public void AddRewardPlus35Like()
    {
        likeAmount += 35;
    }
    public void AddRewardPlus50Like()
    {
        likeAmount += 50;
    }
    
}
