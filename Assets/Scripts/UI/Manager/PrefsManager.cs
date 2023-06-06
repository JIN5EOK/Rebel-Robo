using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    GameManager gameManager;
    ProductData productData;

    string coinAmountKey = "CoinAmount";

    string buyedHeroKey = "BuyedHero";
    string buyedTowerKey = "BuyedTower";
    string buyedSkillKey = "BuyedSkill";
    string buyedEquipKey = "BuyedEquip";

    public float savedcoinAmount = 2f;

    void Awake()
    {
        if (PlayerPrefs.HasKey(coinAmountKey))
        {
            savedcoinAmount = PlayerPrefs.GetFloat(coinAmountKey);
        }
        if (PlayerPrefs.HasKey(buyedHeroKey))
        {
            savedcoinAmount = PlayerPrefs.GetFloat(coinAmountKey);
        }
        if (PlayerPrefs.HasKey(buyedTowerKey))
        {
            savedcoinAmount = PlayerPrefs.GetFloat(coinAmountKey);
        }
        if (PlayerPrefs.HasKey(buyedSkillKey))
        {
            savedcoinAmount = PlayerPrefs.GetFloat(coinAmountKey);
        }
        if (PlayerPrefs.HasKey(buyedEquipKey))
        {
            savedcoinAmount = PlayerPrefs.GetFloat(coinAmountKey);
        }
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(productData != null)
        {
            productData = GameObject.Find("ProductData").GetComponent<ProductData>();
        }
        gameManager.coin = (int)savedcoinAmount;
    }

    // Update is called once per frame
    
}
