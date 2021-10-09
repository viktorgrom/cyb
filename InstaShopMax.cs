using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstaShopMax : MonoBehaviour
{
    public Text likes;
    public Text followers;
    private int likesInt;
    private int followersInt;
    private int instaOff;


    void Start()
    {
        likesInt = PlayerPrefs.GetInt("WinLikes");
        followersInt = PlayerPrefs.GetInt("WinFollowers");

        PlayerPrefs.SetInt("WinLikes", likesInt);
        PlayerPrefs.SetInt("WinFollowers", followersInt);

        likes.text = likesInt.ToString();
        followers.text = followersInt.ToString();
    }

    public void instaOf()
    {
        instaOff = 1;
        PlayerPrefs.SetInt("handShop", instaOff);
    }

    

    


}
