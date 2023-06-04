using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopEvent : MonoBehaviour
{

    public GameObject HeroProducts;
    public GameObject TowerProducts;
    public GameObject SkillProducts;
    public GameObject EquipProducts;

    public GameObject SelectPopup;

    GameManager gameManager;
    ProductData productData;

    public bool popupMenuOn = false;

    public int[] heros = new int[3] {0, 1, 2};
    public int[] towers = new int[6] { 0, 1, 2, 3, 4, 5 };
    public int[] skills = new int[3] { 0, 1, 2};
    public int[] equips = new int[2] { 0, 1 };

    public int selectedMenu;
    public int selectedProduct;

    public TextMeshProUGUI coinAmount;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        productData = GameObject.Find("ProductData").GetComponent<ProductData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectPopup != null)
        {
            if (SelectPopup.activeSelf)
            {
                popupMenuOn = true;
            }
            else
                popupMenuOn = false;
        }
        //HeroProducts.transform.GetChild(0).gameObject.SetActive(true);
        coinAmount.text = gameManager.coin.ToString();

        ChangeBuyText();
    }

    public void menuIndexEvent(int index)
    {
        selectedProduct = 0;
        switch (index)
        {
            case 0:
                selectedMenu = 0;
                HeroProducts.SetActive(true);
                TowerProducts.SetActive(false);
                SkillProducts.SetActive(false);
                EquipProducts.SetActive(false);
                break;
            case 1:
                selectedMenu = 1;
                HeroProducts.SetActive(false);
                TowerProducts.SetActive(true);
                SkillProducts.SetActive(false);
                EquipProducts.SetActive(false);
                break;
            case 2:
                selectedMenu = 2;
                HeroProducts.SetActive(false);
                TowerProducts.SetActive(false);
                SkillProducts.SetActive(true);
                EquipProducts.SetActive(false);
                break;
            case 3:
                selectedMenu = 3;
                HeroProducts.SetActive(false);
                TowerProducts.SetActive(false);
                SkillProducts.SetActive(false);
                EquipProducts.SetActive(true);
                break;
        }
    }

    public void productIndexEvent(int index)
    {
        switch (index)
            {
                case 0:
                    selectedProduct = 0;
                    break;
                case 1:
                    selectedProduct = 1;
                    break;
                case 2:
                    selectedProduct = 2;
                    break;
                case 3:
                    selectedProduct = 3;
                    break;
                case 4:
                    selectedProduct = 4;
                    break;
                case 5:
                    selectedProduct = 5;
                    break;
            }
        
    }
    public void payCredit()
    {
        switch(selectedMenu)
        {
            case 0:
                switch (selectedProduct)
                {
                    case 0:
                        if (gameManager.coin >= productData.priceHero[0])
                        {
                            gameManager.coin -= productData.priceHero[0];
                            productData.buyedHero[0] = true;
                        }
                        break;
                    case 1:
                        if (gameManager.coin >= productData.priceHero[1])
                        {
                            gameManager.coin -= productData.priceHero[1];
                            productData.buyedHero[1] = true;
                        }
                        break;
                    case 2:
                        if (gameManager.coin >= productData.priceHero[2])
                        {
                            gameManager.coin -= productData.priceHero[2];
                            productData.buyedHero[2] = true;
                        }
                        break;
                }
                break;
            case 1:
                switch (selectedProduct)
                {
                    case 0:
                        if (gameManager.coin >= productData.priceTower[0])
                        {
                            gameManager.coin -= productData.priceTower[0];
                            productData.buyedTower[0] = true;
                        }
                        break;
                    case 1:
                        if (gameManager.coin >= productData.priceTower[1])
                        {
                            gameManager.coin -= productData.priceTower[1];
                            productData.buyedTower[1] = true;
                        }
                        break;
                    case 2:
                        if (gameManager.coin >= productData.priceTower[2])
                        {
                            gameManager.coin -= productData.priceTower[2];
                            productData.buyedTower[2] = true;
                        }
                        break;
                    case 3:
                        if (gameManager.coin >= productData.priceTower[3])
                        {
                            gameManager.coin -= productData.priceTower[3];
                            productData.buyedTower[3] = true;
                        }
                        break;
                    case 4:
                        if (gameManager.coin >= productData.priceTower[4])
                        {
                            gameManager.coin -= productData.priceTower[4];
                            productData.buyedTower[4] = true;
                        }
                        break;
                    case 5:
                        if (gameManager.coin >= productData.priceTower[5])
                        {
                            gameManager.coin -= productData.priceTower[5];
                            productData.buyedTower[5] = true;
                        }
                        break;
                }
                break;
            case 2:
                switch (selectedProduct)
                {
                    case 0:
                        if (gameManager.coin >= productData.priceSkill[0])
                        {
                            gameManager.coin -= productData.priceSkill[0];
                            productData.buyedSkill[0] = true;
                        }
                        break;
                    case 1:
                        if (gameManager.coin >= productData.priceSkill[1])
                        {
                            gameManager.coin -= productData.priceSkill[1];
                            productData.buyedSkill[1] = true;
                        }
                        break;
                    case 2:
                        if (gameManager.coin >= productData.priceSkill[2])
                        {
                            gameManager.coin -= productData.priceSkill[2];
                            productData.buyedSkill[2] = true;
                        }
                        break;
                }
                break;
            case 3:
                switch (selectedProduct)
                {
                    case 0:
                        if (gameManager.coin >= productData.priceEquip[0])
                        {
                            gameManager.coin -= productData.priceEquip[0];
                            productData.buyedEquip[0] = true;
                        }
                        break;
                    case 1:
                        if (gameManager.coin >= productData.priceEquip[1])
                        {
                            gameManager.coin -= productData.priceEquip[1];
                            productData.buyedEquip[1] = true;
                        }
                        break;
                }
                break;
        }
        
        
    }

    public void ChangeBuyText()
    {
        
        Transform Hchild = HeroProducts.transform.GetChild(0);
        Transform Hchild2 = Hchild.GetChild(0);

        for (int i = 0; i < productData.buyedHero.Length; i++)
        {
            if (productData.buyedHero[i] == true)
            {
                Hchild2.GetChild(i + 3).transform.gameObject.SetActive(false);
                Hchild2.GetChild(i + 6).transform.gameObject.SetActive(true);
                
            }
        }

        Transform Tchild = TowerProducts.transform.GetChild(0);
        Transform Tchild2 = Tchild.GetChild(0);

        for (int i = 0; i < productData.buyedTower.Length; i++)
        {

            if (productData.buyedTower[i] == true)
            {
                Tchild2.GetChild(i + 6).transform.gameObject.SetActive(false);
                Tchild2.GetChild(i + 12).transform.gameObject.SetActive(true);
                
            }
        }
        Transform Schild = SkillProducts.transform.GetChild(0);
        Transform Schild2 = Schild.GetChild(0);

        for (int i = 0; i < productData.buyedSkill.Length; i++)
        {
            if (productData.buyedSkill[i] == true)
            {
                Schild2.GetChild(i + 3).transform.gameObject.SetActive(false);
                Schild2.GetChild(i + 6).transform.gameObject.SetActive(true);
                
            }
        }

        Transform Echild = EquipProducts.transform.GetChild(0);
        Transform Echild2 = Echild.GetChild(0);

        for (int i = 0; i < productData.buyedEquip.Length; i++)
        {
            if (productData.buyedEquip[i] == true)
            {
                Echild2.GetChild(i + 2).transform.gameObject.SetActive(false);
                Echild2.GetChild(i + 4).transform.gameObject.SetActive(true);
                
            }
        }

    }

    public void startBuying()
    {
        SelectPopup.SetActive(true);
    }
    public void cancleBuying()
    {
        SelectPopup.SetActive(false);
    }

    

    public void ExitShop()
    {
        SceneManager.LoadScene("GameLobby");
    }
}
