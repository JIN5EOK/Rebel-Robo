using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClick : MonoBehaviour
{
    ShopEvent shopEvent;
    ProductData productData;
    SaveManager saveManager;
    // Start is called before the first frame update
    void Start()
    {
        shopEvent = GameObject.Find("ShopEvent").GetComponent<ShopEvent>();
        productData = GameObject.Find("ProductData").GetComponent<ProductData>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();

        if (saveManager == null)
        {
            Debug.LogWarning("SaveManager instance is null in ShopClick script.");
        }
    }

    // Update is called once per frame
    

    public void menuIndex(int index)
    {
        switch (index)
        {
            case 0:
                shopEvent.menuIndexEvent(0);
                break;
            case 1:
                shopEvent.menuIndexEvent(1);
                break;
            case 2:
                shopEvent.menuIndexEvent(2);
                break;
            case 3:
                shopEvent.menuIndexEvent(3);
                break;

        }
        
    }

    public void productIndex(int index)
    {
        if(!shopEvent.popupMenuOn)
        {
            
            switch (index)
            {
                case 0:
                    shopEvent.productIndexEvent(0);
                    break;
                case 1:
                    shopEvent.productIndexEvent(1);
                    break;
                case 2:
                    shopEvent.productIndexEvent(2);
                    break;
                case 3:
                    shopEvent.productIndexEvent(3);
                    break;
                case 4:
                    shopEvent.productIndexEvent(4);
                    break;
                case 5:
                    shopEvent.productIndexEvent(5);
                    break;

            }
            shopEvent.startBuying();
        }
        
    }

    public void clickCancleBuying()
    {
        shopEvent.cancleBuying();
    }

    public void ClickBuying()
    {
        shopEvent.payCredit();
        //productManager.SaveCredit();

        //productManager.SaveBuyedProduct();
        shopEvent.cancleBuying();

        if (saveManager != null)
        {
            saveManager.Save();
        }
    }
    public void ClickPut(int index)
    {
        shopEvent.putProduct(index);
    }

    public void exitShop()
    {
        shopEvent.ExitShop();
    }
}
