using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Advertisements;
using Random = UnityEngine.Random;

public class testDrive : MonoBehaviour, IUnityAdsListener
{
    
     
    [SerializeField] private float _persentShowAds;
    [SerializeField] private bool _testMode = true;

    private string _gameId = "4203673"; //ваш game id

    private string _video = "Interstitial_Android";
    //private string _rewardedVideo = "Rewarded_Android";


    //main
    public float jumpSpeed;
    public float gravity;
    public float rotateSpeed;

    private bool walkBack = false;

    //public testDrive testDriveInstance;


    //test
    public int lol;

    //UpgrateSystem
    public int maxSpeedUpgrate;
    public int maxEnergyUpgrate;
    public int maxLifeUpgrate;

    //timer
    public Text timerText;
    
    private float startTime;
    bool keepTiming;
    float timer;

    //Pets
    public GameObject[] pets;
    public int maxFly;
    private int maxLaska;
    private int maxPanda;
    private float petsMultipleFollowers = 1;

    //timer
    public float tenSec = 100;
    public bool timerRunning = true;
    int i;


    //шкала
    public Image energy_bar;
    public float fill;
    public float energyMinusFloat;
    public float energyUpgrate;
    public GameObject lowEnergyText;
    private bool slow = false;

    public float energyPlus;
    public Image speed_bar; 
    public float speedMove_Current;
    public float speedMoveMax;
    public float speedRecoverySpeedMax;

    public float testSpeed;

    //targetPoiner
    
    public RectTransform PointerUI;
    public Sprite PointerIcon;
    public Sprite OutOfScreenIcon;
    public Sprite CloseScreenIcon;
    private bool blogerClose = false;
    public float InterfaceScale = 100;

    private Vector3 startPointerSize;
    private Camera mainCamera;


    //money-like
    public Text moneyUIText;
    public Text likeUIText;
    public int moneyAmountUI;
    public int likeAmountUI;

    //followers and likes
    public Text followersUIText;
    public Text likesSkalaUIText;
    public Text followersUITextGameOver;   
    public Text likesSkalaUITextGameOver;
    public float followersAmountUIFloat;
    public int followersAmountUIInt;
    public int followersAmountUIIntOLD;
    public float likesShkalaAmountUIFloat;
    public int likesShkalaAmountUIInt;
    public int likesShkalaAmountUIIntOLD;
  

    
    private Transform bloger;    

    public float enemyDistanceFollowers;
    public float distance;

    //loyalty
    public Image barLoyalty;
    public GameObject warningText;   
    public GameObject warningTextLoyalty;
    public GameObject[] shootAnim;
    private float countDown;
    public float fillLoyalty;
    public int shootByBulletBloger;
    private bool shotBloger = false;
    public float shootByBulletBlogerFloat;

    public int HP = 100;

    // gameOver
    public GameObject gameOver;
    public GameObject winDask;

    //winDask
    public Text LikePlusText;
    public Text FollowersPlusText;
    public GameObject[] starsWin;

    public GameObject corona;

    public float fillAmount;

    //healthSystem
    public int currentLifes;
    public int maxNumberLifes;
    


    public Image[] lives;

    public Sprite fullLife;
    public Sprite emptyLife;
    private bool gameover = false;




    private float gravityForce;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController ch_controller;
    private Animator ch_animator;


    //sound
    public AudioSource playerAudio;
    public AudioClip fireSound;
    public AudioClip collideSound;
    public AudioClip presentSound;
    public AudioClip flySound;
    public AudioClip laskaSound;
    public AudioClip pandaSound;

    

    //shooting
    public GameObject bulletPrefab;
    public GameObject playerCamera;

    //reason of Dead
    public Image reasonOfDeadImg;
    public Sprite reasonDeadDog;
    public Sprite reasonDeadCar;
    public Sprite reasonDeadBear;
    public Sprite reasonDeadDove;
    public Sprite reasonDeadPolice;
    public Sprite reasonDeadLoyality;

    // ads off
    public int adsOff = 0;

    //tutorial
    public int tutorialInt;

    
    
    private void Awake()
    {
        startPointerSize = PointerUI.sizeDelta;
        mainCamera = Camera.main;
        
    }

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();

        

        

        //playerAudio = GetComponent<AudioSource>();

        followersAmountUIInt = 0;

        shootByBulletBloger = 0;

        corona.SetActive(false);


        fill = 1f;
        fillAmount = 1f;
        fillLoyalty = 0.5f;
        barLoyalty.fillAmount = fillLoyalty;

        PlusLifeMax();
       
        PlusEnergyMax();

        PlusSpeedPlayer();

        maxFly = PlayerPrefs.GetInt("MaxBoughtFly");
        maxLaska = PlayerPrefs.GetInt("MaxBoughtLaska");
        maxPanda = PlayerPrefs.GetInt("MaxBoughtPanda");

        tutorialInt = PlayerPrefs.GetInt("tutorial");

        BuyFly();
       // BuyLaska();
        //BuyPanda();

        if (GameObject.FindGameObjectWithTag("Bloger"))
            bloger = GameObject.FindGameObjectWithTag("Bloger").transform;

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);

        adsOff = PlayerPrefs.GetInt("AdsOff");
        if (tutorialInt > 0)
        {
            StartTimer();
            

        }

       
    }


    private void Update()
    {
        if (tutorialInt > 0)
        {
            CharacterMove();
            SpeedRecovery();
            HealthSystem();





            //shkala like and followers

            //followersAmountUI = PlayerPrefs.GetFloat("FollowersAmount");
            //likesShkalaAmountUI = PlayerPrefs.GetFloat("LikesShkalaAmount");



            //FollowersAndLikesUpdate();
            Loyalty();


/*
            if (keepTiming)
            {
                UpdateTime();
            }*/

            //PetSound();
            WarningText();

            PetsCheck();
        }

       





    }

    //target pointer
    private void LateUpdate()
    {
        if (bloger)
        {
            Vector3 realPos = mainCamera.WorldToScreenPoint(bloger.position);
            Rect rect = new Rect(0, 0, Screen.width, Screen.height);

            Vector3 outPos = realPos;
            float direction = 1;

            PointerUI.GetComponent<Image>().sprite = OutOfScreenIcon;

            if (!IsBehind(bloger.position) && blogerClose == false)
            {
                if (rect.Contains(realPos))
                {
                    PointerUI.GetComponent<Image>().sprite = PointerIcon;
                    
                }
            } else if (!IsBehind(bloger.position) && blogerClose == true)
            {
                if (rect.Contains(realPos))
                {
                    PointerUI.GetComponent<Image>().sprite = CloseScreenIcon;
                    
                }
            }
            else
            {
                realPos = -realPos;
                outPos = new Vector3(realPos.x, 0, 0);

                if (mainCamera.transform.position.y < bloger.position.y)
                {
                    direction = -1;
                    outPos.y = Screen.height;
                }
            }

            float offset = PointerUI.sizeDelta.x / 2;

            outPos.x = Mathf.Clamp(outPos.x, offset, Screen.width - offset);
            outPos.y = Mathf.Clamp(outPos.y, offset, Screen.height - offset);

            Vector3 pos = realPos - outPos;

            RotatePointer(direction * pos);

            PointerUI.sizeDelta = new Vector2(startPointerSize.x / 100 * InterfaceScale, startPointerSize.y / 100 * InterfaceScale);
            PointerUI.anchoredPosition = outPos;
        }
        else
            Debug.Log("Blogger not found");

        FollowersAndLikesUpdate();



    }
    private bool IsBehind(Vector3 point)
    {
        Vector3 forward = mainCamera.transform.TransformDirection(Vector3.forward);
        Vector3 toOther = point - mainCamera.transform.position;
        if (Vector3.Dot(forward, toOther) < 0) return true;
        return false;
    }

    private void RotatePointer(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        PointerUI.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }



    private void FollowersAndLikesUpdate()
    {
        moneyAmountUI = PlayerPrefs.GetInt("MoneyAmountp");
        likeAmountUI = PlayerPrefs.GetInt("LikeAmount");

        moneyUIText.text = moneyAmountUI.ToString();
        likeUIText.text = likeAmountUI.ToString();

        followersUIText.text = followersAmountUIInt.ToString();
        likesSkalaUIText.text = likesShkalaAmountUIInt.ToString();

        if (GameObject.FindGameObjectWithTag("Bloger"))
        {
            //bloger = GameObject.FindGameObjectWithTag("Bloger").transform;

            distance = Vector3.Distance(transform.position, bloger.transform.position);

            if (distance < enemyDistanceFollowers)
            {

                if (!gameover)
                {
                    blogerClose = true;

                    followersAmountUIFloat += (Time.deltaTime * 500) / distance;
                    followersAmountUIInt = (int)followersAmountUIFloat;
                    Debug.Log("got follower");
                    PlayerPrefs.SetInt("FollowersAmount", followersAmountUIInt);

                    likesShkalaAmountUIFloat += (Time.deltaTime * 3860*petsMultipleFollowers) / distance;
                    likesShkalaAmountUIInt = (int)likesShkalaAmountUIFloat;
                    PlayerPrefs.SetInt("LikesShkalaAmount", likesShkalaAmountUIInt);
                }
                else
                {

                    Debug.Log("like stop");
                }


            }
            else
                blogerClose = false;

            
        }
        else
        {

            Debug.Log("no bloger");
        }

    }

   

    private void CharacterMove()
    {
        if (ch_controller.isGrounded && !gameover)
        {
            ch_animator.ResetTrigger("isJump");

            //ch_animator.ResetTrigger("isPadae");

            //ch_animator.SetBool("isFalling", false);

            moveDirection = new Vector3(0, 0, CrossPlatformInputManager.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (!slow)
            {
                moveDirection *= speedMove_Current;
            } else
                moveDirection *= speedMove_Current/2;


            testSpeed = ch_controller.velocity.magnitude;


            if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.01 && CrossPlatformInputManager.GetAxis("Vertical") > 0.01 && CrossPlatformInputManager.GetAxis("Vertical") < 0.6 || CrossPlatformInputManager.GetAxis("Horizontal") < -0.01 && CrossPlatformInputManager.GetAxis("Vertical") > 0.01 && CrossPlatformInputManager.GetAxis("Vertical") < 0.6 && testSpeed >1f && testSpeed <= 15f)

            {

                //ch_animator.SetBool("isWalk", true);
                ch_animator.SetBool("isRun", true);



                walkBack = false;

                if (fill >= 0f)
                {
                
                fill -= Time.deltaTime * energyMinusFloat;
                energy_bar.fillAmount = fill;
                }


            }

            else if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.01 && CrossPlatformInputManager.GetAxis("Vertical") < -0.01 || CrossPlatformInputManager.GetAxis("Horizontal") < -0.01 && CrossPlatformInputManager.GetAxis("Vertical") < -0.01)
            {
                walkBack = true;
                ch_animator.SetBool("isWalkBack", true);
                


                if (walkBack == true)
                    moveDirection = moveDirection / 3;

                if (fill >= 0f)
                {
                    fill -= Time.deltaTime * energyMinusFloat;
                    energy_bar.fillAmount = fill;
                }
            }

            else if (CrossPlatformInputManager.GetAxis("Vertical") >= 0.6 && testSpeed > 15f)
            {
                

                
                    ch_animator.SetBool("isRun", true);
                    walkBack = false;

                    if (fill >= 0f)
                    {
                        fill -= Time.deltaTime * energyMinusFloat*2;
                        energy_bar.fillAmount = fill;
                    }
                

                

            }
            
            else if(testSpeed == 0)
            {
                ch_animator.SetBool("isWalkBack", false);
                ch_animator.SetBool("isRun", false);
                //ch_animator.SetBool("isWalk", false);
               

                walkBack = false;

                if (fill <= 1f)
                {
                    fill += Time.deltaTime * energyPlus;
                    energy_bar.fillAmount = fill;
                }


            } 
            else
                ch_animator.SetBool("isRun", true);

        }
        /*else
        {
            if (!ch_controller.isGrounded)
                ch_animator.SetBool("isFalling", true);
        }*/

        moveDirection.y -= gravity * Time.deltaTime;

        ch_controller.Move(moveDirection * Time.deltaTime);

        transform.Rotate(0, CrossPlatformInputManager.GetAxis("Horizontal"), 0);

        

        
    }

    



    public void HealthSystem()
    {
        if (currentLifes > maxNumberLifes)
        {
            currentLifes = maxNumberLifes;
        }


        for (int i = 0; i < lives.Length; i++)
        {
            if (i < currentLifes)
            {
                lives[i].sprite = fullLife;
            }
            else
            {
                lives[i].sprite = emptyLife;
            }



            if (i < maxNumberLifes)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }

    public void Fire()
    {
        

        if (ch_controller.isGrounded && likeAmountUI>=1)
        {
            //SoundManagerScript.PlaySound("click");
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;
            likeAmountUI--;
            PlayerPrefs.SetInt("LikeAmount", likeAmountUI);
            playerAudio.PlayOneShot(fireSound);

            if (moveDirection.x == 0 || moveDirection.z == 0)
            {
                ch_animator.Play("throwStop");
                
                
            }
            else
            {
                ch_animator.Play("throw");
            }
        }


    }

    public void Jump()
    {
       

        if (ch_controller.isGrounded)
        {

            moveDirection.y = jumpSpeed;
            ch_controller.Move(moveDirection*Time.deltaTime);
            ch_animator.Play("jump");
            //ch_animator.Play("isPadae");




            if (fill >= 0f)
            {
                fill -= 0.15f;
                energy_bar.fillAmount = fill;
            }

            
        }      
    }
   


    void OnCollisionEnter(Collision collision)
    {
            
        if(collision.collider.tag == "1" || collision.collider.tag == "car" || collision.collider.tag == "dog" || collision.collider.tag == "dove" || collision.collider.tag == "bear" || collision.collider.tag == "policeman")
        {
            Debug.Log(collision.gameObject.name);
            if (speedMove_Current >= 8f)
            {
                speedMove_Current -= 8f;
                fillAmount = speedMove_Current / speedMoveMax;
               
                speed_bar.fillAmount = fillAmount;

                corona.SetActive(true);
                playerAudio.PlayOneShot(collideSound, 0.1f);

                /*if(collision.collider.tag == "EnemyDamage")
                {
                    Destroy(this.gameObject);
                */
            }           

        }

        if(collision.collider.tag == "dog")
        {
            if (currentLifes > 1)
            {
                currentLifes -= 1;
                playerAudio.PlayOneShot(collideSound);
            } else
            {
                gameover = true;
                if (gameover)
                {
                    currentLifes -= 1;                   
                    
                    GameOver();
                    reasonOfDeadImg.sprite = reasonDeadDog;
                }
                
            }
            
        }

        if (collision.collider.tag == "dove")
        {
            if (currentLifes > 1)
            {
                currentLifes -= 1;
                playerAudio.PlayOneShot(collideSound);
            }
            else
            {
                gameover = true;
                if (gameover)
                {
                    currentLifes -= 1;

                    GameOver();
                    reasonOfDeadImg.sprite = reasonDeadDove;
                }

            }

        }

        if (collision.collider.tag == "policeman")
        {
            if (currentLifes > 1)
            {
                currentLifes -= 1;
                playerAudio.PlayOneShot(collideSound);
            }
            else
            {
                gameover = true;
                if (gameover)
                {
                    currentLifes -= 1;

                    GameOver();
                    reasonOfDeadImg.sprite = reasonDeadPolice;
                }

            }

        }
        if (collision.collider.tag == "bear")
        {
            if (currentLifes > 1)
            {
                currentLifes -= 1;
                playerAudio.PlayOneShot(collideSound);
            }
            else
            {
                gameover = true;
                if (gameover)
                {
                    currentLifes -= 1;

                    GameOver();
                    reasonOfDeadImg.sprite = reasonDeadBear;
                }

            }

        }

        if (collision.collider.tag == "car")
        {
            if (currentLifes > 1)
            {
                Vector3 pushVector = new Vector3(0f, 0f, -90f);

                currentLifes -= 1;
                playerAudio.PlayOneShot(collideSound);

                ch_controller.Move(pushVector * 50f * Time.deltaTime);
                
            }
            else
            {
                gameover = true;
                if (gameover)
                {
                    currentLifes -= 1;

                    GameOver();
                    reasonOfDeadImg.sprite = reasonDeadCar;

                }

            }
        }

        if (collision.collider.tag == "presentLive")
        {
            
            playerAudio.PlayOneShot(presentSound);

            if (currentLifes < 3)
            {
                currentLifes += 1;
            }
            else
            {
                currentLifes = 3;

            }

        }

        if (collision.collider.tag == "presentLike" )
        {
            
            playerAudio.PlayOneShot(presentSound);
            likeAmountUI += 5;
            likeUIText.text = likeAmountUI.ToString();
            PlayerPrefs.SetInt("LikeAmount", likeAmountUI);

        }

        if (collision.collider.tag == "PresentGold")
        {
            
            playerAudio.PlayOneShot(presentSound);
            moneyAmountUI += 10;
            moneyUIText.text = moneyAmountUI.ToString();
            PlayerPrefs.SetInt("MoneyAmountp", moneyAmountUI);
        }




        if (collision.gameObject.GetComponent<testEnemy>())
        {
            collision.gameObject.GetComponent<testEnemy>().OnHit();
        }
    }

    void SpeedRecovery()
    {
        
        if(speedMove_Current < speedRecoverySpeedMax)
        {
            speedMove_Current += 5f * Time.deltaTime;
            fillAmount = speedMove_Current / speedMoveMax;

            speed_bar.fillAmount = fillAmount;
        } else
        {
            //speedMove_Current = 25f;
            corona.SetActive(false);
            fillAmount = speedMove_Current / speedMoveMax;

            speed_bar.fillAmount = fillAmount;
        }
        
        
    }

    private void GameOver()
    {
        if(adsOff == 0)
        {
            ShowAd();
        }
        

        ch_animator.Play("gameover");
        gameOver.SetActive(true);
        gameover = true;
        fillLoyalty = 0.9f;
        speedMove_Current = 0;
        ch_controller.enabled = true;

        followersUITextGameOver.text = followersAmountUIInt.ToString();
        likesSkalaUITextGameOver.text = likesShkalaAmountUIInt.ToString();

        followersUIText.text = followersAmountUIInt.ToString();
        likeUIText.text = likeAmountUI.ToString();

        followersAmountUIIntOLD = PlayerPrefs.GetInt("WinFollowers");
        likesShkalaAmountUIIntOLD = PlayerPrefs.GetInt("WinLikes");

        followersAmountUIInt += followersAmountUIIntOLD;
        likesShkalaAmountUIInt += likesShkalaAmountUIIntOLD;

        PlayerPrefs.SetInt("WinLikes", likesShkalaAmountUIInt);
        PlayerPrefs.SetInt("WinFollowers", followersAmountUIInt);

        
        //StopTimer();
        
        
    }
    

    public void Loyalty()
    {

        //shootByBulletBloger = PlayerPrefs.GetInt("ShootBloger");

        //shootByBulletBlogerFloat = (float) shootByBulletBloger;

        if (GameObject.FindGameObjectWithTag("Bloger"))
        {
           // bloger = GameObject.FindGameObjectWithTag("Bloger").transform;

            distance = Vector3.Distance(transform.position, bloger.transform.position);

            if (distance < enemyDistanceFollowers)
            {

                if (fillLoyalty < 1f)
                {
                    

                    if (fillLoyalty < 0.5f && shootByBulletBloger == 0)
                    {
                        fillLoyalty += (Time.deltaTime * 1.2f) / distance;
                        barLoyalty.fillAmount = fillLoyalty;

                    } else if(fillLoyalty < 0.6f && shootByBulletBloger == 1)
                    {
                        fillLoyalty += (Time.deltaTime * 1.2f) / distance;
                        barLoyalty.fillAmount = fillLoyalty;
                    }
                    else if (fillLoyalty < 0.7f && shootByBulletBloger == 2)
                    {
                        fillLoyalty += (Time.deltaTime * 1.2f) / distance;
                        barLoyalty.fillAmount = fillLoyalty;
                    }
                    else if (fillLoyalty < 0.8f && shootByBulletBloger == 3)
                    {
                        fillLoyalty += (Time.deltaTime * 1.2f) / distance;
                        barLoyalty.fillAmount = fillLoyalty;
                    }
                    else if (fillLoyalty < 0.9f && shootByBulletBloger == 4)
                    {
                        fillLoyalty += (Time.deltaTime * 1.2f) / distance;
                        barLoyalty.fillAmount = fillLoyalty;
                    }
                    else if (fillLoyalty < 1f && shootByBulletBloger >= 5)
                    {
                        fillLoyalty += (Time.deltaTime * 1.1f) / distance;
                        barLoyalty.fillAmount = fillLoyalty;
                        if (fillLoyalty >= 1f)
                        {
                            Win();
                        }
                            
                    }
                    else
                    {
                        fillLoyalty = 0.5f;
                        barLoyalty.fillAmount = fillLoyalty;
                    }

                  

                }

            } else if (distance >= enemyDistanceFollowers)
            {
                if (!gameover)
                {
                    if (followersAmountUIInt < 5000)
                    {
                        fillLoyalty -= Time.deltaTime * 0.01f;
                        barLoyalty.fillAmount = fillLoyalty;
                    }
                    else
                    {
                        fillLoyalty -= Time.deltaTime * 0.014f;
                        barLoyalty.fillAmount = fillLoyalty;
                    }
                    

                    
                }
                

                



                
            }

            
        }
        else
        {

            Debug.Log("bloger not found");
        }



        if (shotBloger && fillLoyalty<=0)
        {
            Win();
            
            fillLoyalty = 0.9f;
        }

        if (fillLoyalty < -0.05f)
        {
            GameOver();
            reasonOfDeadImg.sprite = reasonDeadLoyality;
            
        }
        else
            Debug.Log("loyal work 3");


    }
    public void BuyFly()
    {
        if (maxFly>=1 && maxFly<=10)
        {
            pets[0].SetActive(true);

        } else
            pets[0].SetActive(false);

    }
    /*public void BuyLaska()
    {
        if (maxLaska >= 11 && maxLaska <= 20)
        {
            pets[1].SetActive(true);
        }
        else
            pets[1].SetActive(false);
    }
    public void BuyPanda()
    {
        if (maxPanda >= 31)
        {
            pets[2].SetActive(true);
        }
        else
            pets[2].SetActive(false);
    }*/

    private void Win()
    {

        if (adsOff == 0)
        {
            ShowAd();
        }

        Debug.Log("Win On");
        gameover = true;
        speedMove_Current = 0;
        ch_animator.Play("win");
        winDask.SetActive(true);            

        if (shootByBulletBloger == 1)
        {
            starsWin[0].SetActive(true);
            moneyAmountUI += 10;         
            followersAmountUIInt += 5000;            
        }
            
        
        else if (shootByBulletBloger == 2)
        {
            starsWin[1].SetActive(true);
            moneyAmountUI += 20;
            followersAmountUIInt += 10000;
        }
            
        else if (shootByBulletBloger == 3)
        {
            starsWin[2].SetActive(true);
            moneyAmountUI += 30;
            followersAmountUIInt += 15000;
        }
            
        else if (shootByBulletBloger == 4)
        {
            starsWin[3].SetActive(true);
            moneyAmountUI += 40;
            followersAmountUIInt += 20000;
        }
            
        else if (shootByBulletBloger >= 5)
        {
            starsWin[4].SetActive(true);
            moneyAmountUI += 100;
            followersAmountUIInt += 30000;
        }
            
        else starsWin[0].SetActive(true);

        FollowersPlusText.text = followersAmountUIInt.ToString();
        LikePlusText.text = likesShkalaAmountUIInt.ToString();

        followersAmountUIIntOLD = PlayerPrefs.GetInt("WinFollowers");
        likesShkalaAmountUIIntOLD = PlayerPrefs.GetInt("WinLikes");

        followersAmountUIInt += followersAmountUIIntOLD;
        likesShkalaAmountUIInt += likesShkalaAmountUIIntOLD;

        PlayerPrefs.SetInt("WinLikes", likesShkalaAmountUIInt);
        PlayerPrefs.SetInt("WinFollowers", followersAmountUIInt);

        PlayerPrefs.SetInt("MoneyAmountp", moneyAmountUI);
    }

    public void ShootBloger()
    {
        shootByBulletBloger++;
        StartCoroutine(StartCounterShot());
        shotBloger = true;
    }


    public void OnAttack()
    {
        //fillLoyalty += 0.1f;
        shootByBulletBloger++;

        Debug.Log("Bloger got Bullet");
    }

    /*void Footstep()
    {
        int randInd = UnityEngine.Random.Range(0, footsteps.Length);

        playerAudio.PlayOneShot(footsteps[randInd]);

    }*/
    public void PlusEnergyMax()
    {
        maxEnergyUpgrate = PlayerPrefs.GetInt("UpgrateMaxEnergy");
        energyMinusFloat -= (float)maxEnergyUpgrate / 1000;
        energyPlus += (float)maxEnergyUpgrate / 1000;
        
        
    }

    public void PlusLifeMax()
    {
        maxLifeUpgrate = PlayerPrefs.GetInt("UpgrateMaxLife");

        if(maxLifeUpgrate >= 5 && maxLifeUpgrate < 10)
        {
            currentLifes = 2;
        } else if (maxLifeUpgrate >= 10)
        {
            currentLifes = 3;
        }
        else
        {
            currentLifes = 1;
        }
    }

    public void PlusSpeedPlayer()
    {
        speedMove_Current = 25f;
        speedMoveMax = 25f;
        speedRecoverySpeedMax = 25f;

        maxSpeedUpgrate = PlayerPrefs.GetInt("UpgrateMaxSpeed");

        speedMove_Current += maxSpeedUpgrate;
        speedMoveMax += maxSpeedUpgrate;
        speedRecoverySpeedMax += maxSpeedUpgrate;

        
    }

    //timer
   /* void UpdateTime()
    {
        
        timer = Time.time - startTime;
        timerText.text = TimeToString(timer);

    }

    float StopTimer()
    {
        keepTiming = false;
        
        
        return timer;
    }

    void ResumeTimer()
    {
        keepTiming = true;
        startTime = Time.time - timer;
    }*/

    void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    string TimeToString(float t)
    {
        
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        return minutes + ":" + seconds;
        
    }

    private void PetSound()
    {
        if(maxFly > 0)
        {
            if (timerRunning)
            {
                tenSec -= Time.smoothDeltaTime;
                if (tenSec >= 0)
                {

                    playerAudio.PlayOneShot(flySound);
                    //Debug.Log(i++);
                }
                else
                {
                    Debug.Log("Done");
                    timerRunning = false;
                }
            }
            
        }
        if (maxLaska > 0)
        {
            playerAudio.PlayOneShot(laskaSound);
        }
        if (maxPanda > 0)
        {
            playerAudio.PlayOneShot(pandaSound);
        }
    }

    private void WarningText()
    {
        if(fillLoyalty < 0.15 && fillLoyalty>0.12)
        {
            warningText.SetActive(true);
            warningTextLoyalty.SetActive(true);
        }
        else if (fillLoyalty < 0.03)
        {
            warningText.SetActive(true);
            warningTextLoyalty.SetActive(true);
        }
        else if (fillLoyalty <= 0)
        {
            warningText.SetActive(false);
            warningTextLoyalty.SetActive(false);
        }
        else
        {
            warningText.SetActive(false);
            warningTextLoyalty.SetActive(false);
        }

        if (fill <= 0.05)
        {
            lowEnergyText.SetActive(true);
            slow = true;
            
        }
        else if(fill > 0.05)
        {
            lowEnergyText.SetActive(false);
            slow = false;
        }
           
    }

    private IEnumerator StartCounterShot()
    {
        countDown = 1f;

        for (int i = 0; i < 1000; i++)
        {
            while (countDown >= 0)
            {
                if (shootByBulletBloger == 1)
                    shootAnim[0].SetActive(true);
                else if (shootByBulletBloger == 2)
                    shootAnim[1].SetActive(true);
                else if (shootByBulletBloger == 3)
                    shootAnim[2].SetActive(true);
                else if (shootByBulletBloger == 4)
                    shootAnim[3].SetActive(true);
                else
                    shootAnim[4].SetActive(true);

                countDown -= Time.smoothDeltaTime;
                yield return null;
            }
            shootAnim[0].SetActive(false);
            shootAnim[1].SetActive(false);
            shootAnim[2].SetActive(false);
            shootAnim[3].SetActive(false);
            shootAnim[4].SetActive(false);
        }
    }

    private void PetsCheck()
    {
        if (maxFly == 1)
        {
            petsMultipleFollowers = 1.2f;
        }
        else
            petsMultipleFollowers = 1f;
    }

    public void TutorialLastClicked()
    {
        tutorialInt = 1;
        PlayerPrefs.SetInt("tutorial", tutorialInt);
    }

    

    //Ads
    public static void ShowAdsVideo(string placementId) //инициализация рекламы по типу
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisement not ready!");
        }
    }



    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _video)
        {
            //действия, если реклама доступна
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        //ошибка рекламы
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // только запустили рекламу
    } 

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) //обработка рекламы (тут определеяем вознаграждение)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("+1 ads");
            //действия, если пользователь посмотрел рекламу до конца
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("+skip ads");
            //действия, если пользователь пропустил рекламу + ЧАПОЛЬ
        }
        else if (showResult == ShowResult.Failed)
        {
            //действия при ошибке
        }
    }

    public void ShowAd()
    {
        float tempPersent = Random.Range(0f, 0.5f);

        if (followersAmountUIInt > 50000)
        {
            tempPersent = Random.Range(0f, 0.8f);
        }
        
        

        if (tempPersent < _persentShowAds)
            ShowAdsVideo("Interstitial_Android");
    }

    
}


