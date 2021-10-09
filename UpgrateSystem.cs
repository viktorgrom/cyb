using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrateSystem : MonoBehaviour
{
    public GameObject[] speedMaxObjs;
    public int selectedUpgrate;

    public GameObject[] energyMaxObjs;
    public int selectedUpgrateEnergyMax;

    public GameObject[] lifesMaxObjs;
    public int selectedUpgrateLifeMax;

    private bool uprgSpeedMax = false;
    private bool uprgEnergyMax =false;
    private bool uprgLifeMax =false;

    private int moneyAmount;


    private void Start()
    {
        selectedUpgrate = PlayerPrefs.GetInt("UpgrateMaxSpeed");
        selectedUpgrateEnergyMax = PlayerPrefs.GetInt("UpgrateMaxEnergy");
        selectedUpgrateLifeMax = PlayerPrefs.GetInt("UpgrateMaxLife");

        CheckUpgrateMax();
        //selectedUpgrate = PlayerPrefs.GetInt("UpgrateMaxSpeed");
        //selectedUpgrateEnergyMax = PlayerPrefs.GetInt("UpgrateMaxEnergy");
        //selectedUpgrateLifeMax = PlayerPrefs.GetInt("UpgrateMaxLife");
        //PlayerPrefs.SetInt("UprgateMaxSpeed", selectedUpgrate);
    }
    private void Update()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmountp");
        PlayerPrefs.SetInt("UpgrateMaxSpeed", selectedUpgrate);
        PlayerPrefs.SetInt("UpgrateMaxEnergy", selectedUpgrateEnergyMax);
        PlayerPrefs.SetInt("UpgrateMaxLife", selectedUpgrateLifeMax);
        CheckUpgrateMax();
    }

    private void CheckUpgrateMax()
    {
        if(selectedUpgrate == 1)
        {
            speedMaxObjs[1].SetActive(true);
        }else if (selectedUpgrate == 2)
        {
            speedMaxObjs[2].SetActive(true);
        }
        else if (selectedUpgrate == 3)
        {
            speedMaxObjs[3].SetActive(true);
        }
        else if (selectedUpgrate == 4)
        {
            speedMaxObjs[4].SetActive(true);
        }
        else if (selectedUpgrate == 5)
        {
            speedMaxObjs[5].SetActive(true);
        }
        else if (selectedUpgrate == 6)
        {
            speedMaxObjs[6].SetActive(true);
        }
        else if (selectedUpgrate == 7)
        {
            speedMaxObjs[7].SetActive(true);
        }
        else if (selectedUpgrate == 8)
        {
            speedMaxObjs[8].SetActive(true);
        }
        else if (selectedUpgrate == 9)
        {
            speedMaxObjs[9].SetActive(true);
        }
        else if (selectedUpgrate == 10)
        {
            speedMaxObjs[10].SetActive(true);
            //uprgSpeedMax = true;
        }
        else
        {
            speedMaxObjs[0].SetActive(true);
            speedMaxObjs[1].SetActive(false);
            speedMaxObjs[2].SetActive(false);
            speedMaxObjs[3].SetActive(false);
            speedMaxObjs[4].SetActive(false);
            speedMaxObjs[5].SetActive(false);
            speedMaxObjs[6].SetActive(false);
            speedMaxObjs[7].SetActive(false);
            speedMaxObjs[8].SetActive(false);
            speedMaxObjs[9].SetActive(false);
            speedMaxObjs[10].SetActive(false);
        }

        if (selectedUpgrateEnergyMax == 1)
        {
            energyMaxObjs[1].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 2)
        {
            energyMaxObjs[2].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 3)
        {
            energyMaxObjs[3].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 4)
        {
            energyMaxObjs[4].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 5)
        {
            energyMaxObjs[5].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 6)
        {
            energyMaxObjs[6].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 7)
        {
            energyMaxObjs[7].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 8)
        {
            energyMaxObjs[8].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 9)
        {
            energyMaxObjs[9].SetActive(true);
        }
        else if (selectedUpgrateEnergyMax == 10)
        {
            energyMaxObjs[10].SetActive(true);
            uprgEnergyMax = true;
        }
        else
        {
            energyMaxObjs[0].SetActive(true);
            energyMaxObjs[1].SetActive(false);
            energyMaxObjs[2].SetActive(false);
            energyMaxObjs[3].SetActive(false);
            energyMaxObjs[4].SetActive(false);
            energyMaxObjs[5].SetActive(false);
            energyMaxObjs[6].SetActive(false);
            energyMaxObjs[7].SetActive(false);
            energyMaxObjs[8].SetActive(false);
            energyMaxObjs[9].SetActive(false);
            energyMaxObjs[10].SetActive(false);
        }


        if (selectedUpgrateLifeMax == 1)
        {
            lifesMaxObjs[1].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 2)
        {
            lifesMaxObjs[2].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 3)
        {
            lifesMaxObjs[3].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 4)
        {
            lifesMaxObjs[4].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 5)
        {
            lifesMaxObjs[5].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 6)
        {
            lifesMaxObjs[6].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 7)
        {
            lifesMaxObjs[7].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 8)
        {
            lifesMaxObjs[8].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 9)
        {
            lifesMaxObjs[9].SetActive(true);
        }
        else if (selectedUpgrateLifeMax == 10)
        {
            lifesMaxObjs[10].SetActive(true);
            uprgLifeMax = true;
        }
        else
        {
            lifesMaxObjs[0].SetActive(true);
            lifesMaxObjs[1].SetActive(false);
            lifesMaxObjs[2].SetActive(false);
            lifesMaxObjs[3].SetActive(false);
            lifesMaxObjs[4].SetActive(false);
            lifesMaxObjs[5].SetActive(false);
            lifesMaxObjs[6].SetActive(false);
            lifesMaxObjs[7].SetActive(false);
            lifesMaxObjs[8].SetActive(false);
            lifesMaxObjs[9].SetActive(false);
            lifesMaxObjs[10].SetActive(false);
        }
    }

    public void NextUpgrateSpeedMax()
    {
        //selectedUpgrate = PlayerPrefs.GetInt("UpgrateMaxSpeed");

        

        if (selectedUpgrate <= 10 && moneyAmount >=50 && !uprgSpeedMax) 
        {
            speedMaxObjs[selectedUpgrate].SetActive(false);
            selectedUpgrate = (selectedUpgrate + 1) % speedMaxObjs.Length;
            speedMaxObjs[selectedUpgrate].SetActive(true);
            moneyAmount -= 50;
            PlayerPrefs.SetInt("MoneyAmountp", moneyAmount);

            //PlayerPrefs.SetInt("UpgrateMaxSpeed", selectedUpgrate);
        }
        /*else
        {
            speedMaxObjs[0].SetActive(false);
            speedMaxObjs[1].SetActive(false);
            speedMaxObjs[2].SetActive(false);
            speedMaxObjs[3].SetActive(false);
            speedMaxObjs[4].SetActive(false);
            speedMaxObjs[5].SetActive(false);
            speedMaxObjs[6].SetActive(false);
            speedMaxObjs[7].SetActive(false);
            speedMaxObjs[8].SetActive(false);
            speedMaxObjs[9].SetActive(false);
            speedMaxObjs[10].SetActive(true);
            selectedUpgrate = 10;
        }*/
            

    }
    public void NextUpgrateEnergyMax()
    {
        //selectedUpgrateEnergyMax = PlayerPrefs.GetInt("UpgrateMaxEnergy");



        if (selectedUpgrateEnergyMax <= 10 && moneyAmount >= 50 && !uprgEnergyMax)
        {
            energyMaxObjs[selectedUpgrateEnergyMax].SetActive(false);
            selectedUpgrateEnergyMax = (selectedUpgrateEnergyMax + 1) % energyMaxObjs.Length;
            energyMaxObjs[selectedUpgrateEnergyMax].SetActive(true);
            moneyAmount -= 50;
            PlayerPrefs.SetInt("MoneyAmountp", moneyAmount);


        }
        /*else
        {
            energyMaxObjs[0].SetActive(false);
            energyMaxObjs[1].SetActive(false);
            energyMaxObjs[2].SetActive(false);
            energyMaxObjs[3].SetActive(false);
            energyMaxObjs[4].SetActive(false);
            energyMaxObjs[5].SetActive(false);
            energyMaxObjs[6].SetActive(false);
            energyMaxObjs[7].SetActive(false);
            energyMaxObjs[8].SetActive(false);
            energyMaxObjs[9].SetActive(false);
            energyMaxObjs[10].SetActive(true);
            selectedUpgrateEnergyMax = 10;
        }*/
    }
    public void NextUpgrateLifeMax()
    {
        //selectedUpgrateLifeMax = PlayerPrefs.GetInt("UpgrateMaxLife");



        if (selectedUpgrateLifeMax <= 10 && moneyAmount >= 50 && !uprgLifeMax)
        {
            lifesMaxObjs[selectedUpgrateLifeMax].SetActive(false);
            selectedUpgrateLifeMax = (selectedUpgrateLifeMax + 1) % lifesMaxObjs.Length;
            lifesMaxObjs[selectedUpgrateLifeMax].SetActive(true);
            moneyAmount -= 50;
            PlayerPrefs.SetInt("MoneyAmountp", moneyAmount);


        }
       /* else
        {
            lifesMaxObjs[0].SetActive(false);
            lifesMaxObjs[1].SetActive(false);
            lifesMaxObjs[2].SetActive(false);
            lifesMaxObjs[3].SetActive(false);
            lifesMaxObjs[4].SetActive(false);
            lifesMaxObjs[5].SetActive(false);
            lifesMaxObjs[6].SetActive(false);
            lifesMaxObjs[7].SetActive(false);
            lifesMaxObjs[8].SetActive(false);
            lifesMaxObjs[9].SetActive(false);
            lifesMaxObjs[10].SetActive(true);
            selectedUpgrateLifeMax = 10;

        }*/




    }
}
