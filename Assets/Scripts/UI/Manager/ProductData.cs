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
        products.Add("������ Ÿ��", new Product("������ Ÿ��", true, 2));
        products.Add("��� Ÿ��", new Product("��� Ÿ��", false, 4));
        products.Add("����� Ÿ��", new Product("����� Ÿ��", false, 6));
        products.Add("���� Ÿ��", new Product("���� Ÿ��", false, 8));
        products.Add("Tower_5", new Product("Tower_5", false, 10));
        products.Add("Tower_6", new Product("Tower_6", false, 12));

        // Skill
        products.Add("��ź", new Product("��ź", false, 4));
        products.Add("�ٸ�����Ʈ", new Product("�ٸ�����Ʈ", false, 8));
        products.Add("����", new Product("����", false, 12));

        // Equip
        products.Add("��ġ", new Product("��ġ", true, 0));
        products.Add("��ġ_2", new Product("��ġ_2", false, 20));
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
        buyedTower[0] = shopData.IsProductPurchased("������ Ÿ��");
        buyedTower[1] = shopData.IsProductPurchased("��� Ÿ��");
        buyedTower[2] = shopData.IsProductPurchased("����� Ÿ��");
        buyedTower[3] = shopData.IsProductPurchased("���� Ÿ��");
        buyedTower[4] = shopData.IsProductPurchased("Tower_5");
        buyedTower[5] = shopData.IsProductPurchased("Tower_6");

        buyedSkill = new bool[3];
        buyedSkill[0] = shopData.IsProductPurchased("��ź");
        buyedSkill[1] = shopData.IsProductPurchased("�ٸ�����Ʈ");
        buyedSkill[2] = shopData.IsProductPurchased("����");

        buyedEquip = new bool[2];
        buyedEquip[0] = shopData.IsProductPurchased("��ġ");
        buyedEquip[1] = shopData.IsProductPurchased("��ġ_2");

        priceHero = new int[3];
        priceHero[0] = shopData.GetProductPrice("Hero_1");
        priceHero[1] = shopData.GetProductPrice("Hero_2");
        priceHero[2] = shopData.GetProductPrice("Hero_3");

        priceTower = new int[6];
        priceTower[0] = shopData.GetProductPrice("������ Ÿ��");
        priceTower[1] = shopData.GetProductPrice("��� Ÿ��");
        priceTower[2] = shopData.GetProductPrice("����� Ÿ��");
        priceTower[3] = shopData.GetProductPrice("���� Ÿ��");
        priceTower[4] = shopData.GetProductPrice("Tower_5");
        priceTower[5] = shopData.GetProductPrice("Tower_6");

        priceSkill = new int[3];
        priceSkill[0] = shopData.GetProductPrice("��ź");
        priceSkill[1] = shopData.GetProductPrice("�ٸ�����Ʈ");
        priceSkill[2] = shopData.GetProductPrice("����");

        priceEquip = new int[2];
        priceEquip[0] = shopData.GetProductPrice("��ġ");
        priceEquip[1] = shopData.GetProductPrice("��ġ_2");
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
