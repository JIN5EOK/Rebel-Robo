using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ProductType
{
    Hero,
    Tower,
    Skill,
    Equip
}
public class Product
{
    public string Name { get; set; }
    public bool IsPurchased { get; set; }
    public int Price { get; set; }

    public Product(string name, bool isPurchased, int price)
    {
        Name = name;
        IsPurchased = isPurchased;
        Price = price;
    }
}
public class ShopData
{
    private Dictionary<string, Product> products = new Dictionary<string, Product>();

    public ShopData()
    {
        // Hero
        products.Add("Hero_1", new Product("Hero_1", true, 10)); 
        products.Add("Hero_2", new Product("Hero_2", false, 20));
        products.Add("Hero_3", new Product("Hero_3", false, 30));

        // Tower
        products.Add("레이저 타워", new Product("레이저 타워", true, 2));
        products.Add("방사 타워", new Product("방사 타워", false, 4));
        products.Add("기관총 타워", new Product("기관총 타워", false, 6));
        products.Add("로켓 타워", new Product("로켓 타워", false, 8));
        products.Add("Tower_5", new Product("Tower_5", false, 10));
        products.Add("Tower_6", new Product("Tower_6", false, 12));

        // Skill
        products.Add("폭탄", new Product("폭탄", false, 4));
        products.Add("바리게이트", new Product("바리게이트", false, 8));
        products.Add("버프", new Product("버프", false, 12));

        // Equip
        products.Add("망치", new Product("망치", true, 0));
        products.Add("망치_2", new Product("망치_2", false, 20));
    }

    public bool IsProductPurchased(string productName)
    {
        if (products.ContainsKey(productName))
        {
            return products[productName].IsPurchased;
        }
        else
        {
            throw new ArgumentException("Invalid product");
        }
    }

    public int GetProductPrice(string productName)
    {
        if (products.ContainsKey(productName))
        {
            return products[productName].Price;
        }
        else
        {
            throw new ArgumentException("Invalid product");
        }
    }
}
public class ProductData : MonoBehaviour
{
    ShopData shopData;

    public bool[] buyedHero = new bool[3];
    public bool[] buyedTower = new bool[6];
    public bool[] buyedSkill = new bool[3];
    public bool[] buyedEquip = new bool[2];

    public int[] priceHero = new int[3] { 10, 20, 30 };
    public int[] priceTower = new int[6] { 2, 4, 6, 8, 10, 12 };
    public int[] priceSkill = new int[3] { 4, 8, 12};
    public int[] priceEquip = new int[2] { 0, 20 };

    
    public static ProductData Instance;

    GameManager gameManager;
    public ProductData()
    {
        shopData = new ShopData();

        buyedHero = new bool[3];
        buyedHero[0] = shopData.IsProductPurchased("Hero_1");
        buyedHero[1] = shopData.IsProductPurchased("Hero_2");
        buyedHero[2] = shopData.IsProductPurchased("Hero_3");

        buyedTower = new bool[6];
        buyedTower[0] = shopData.IsProductPurchased("레이저 타워");
        buyedTower[1] = shopData.IsProductPurchased("방사 타워");
        buyedTower[2] = shopData.IsProductPurchased("기관총 타워");
        buyedTower[3] = shopData.IsProductPurchased("로켓 타워");
        buyedTower[4] = shopData.IsProductPurchased("Tower_5");
        buyedTower[5] = shopData.IsProductPurchased("Tower_6");

        buyedSkill = new bool[3];
        buyedSkill[0] = shopData.IsProductPurchased("폭탄");
        buyedSkill[1] = shopData.IsProductPurchased("바리게이트");
        buyedSkill[2] = shopData.IsProductPurchased("버프");

        buyedEquip = new bool[2];
        buyedEquip[0] = shopData.IsProductPurchased("망치");
        buyedEquip[1] = shopData.IsProductPurchased("망치_2");

        priceHero = new int[3];
        priceHero[0] = shopData.GetProductPrice("Hero_1");
        priceHero[1] = shopData.GetProductPrice("Hero_2");
        priceHero[2] = shopData.GetProductPrice("Hero_3");

        priceTower = new int[6];
        priceTower[0] = shopData.GetProductPrice("레이저 타워");
        priceTower[1] = shopData.GetProductPrice("방사 타워");
        priceTower[2] = shopData.GetProductPrice("기관총 타워");
        priceTower[3] = shopData.GetProductPrice("로켓 타워");
        priceTower[4] = shopData.GetProductPrice("Tower_5");
        priceTower[5] = shopData.GetProductPrice("Tower_6");

        priceSkill = new int[3];
        priceSkill[0] = shopData.GetProductPrice("폭탄");
        priceSkill[1] = shopData.GetProductPrice("바리게이트");
        priceSkill[2] = shopData.GetProductPrice("버프");

        priceEquip = new int[2];
        priceEquip[0] = shopData.GetProductPrice("망치");
        priceEquip[1] = shopData.GetProductPrice("망치_2");
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


   
}
