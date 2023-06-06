using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollViewManager : MonoBehaviour
{
    //ScrollRect scrollRect;

    public List<GameObject> towerProducts = new List<GameObject>();

    RectTransform rectTransform;



    void Start()
    {
       
       rectTransform = GetComponent<RectTransform>();
       for (int i = 0; i < transform.childCount; i++)
       {
           towerProducts.Add(transform.GetChild(i).gameObject);
       }
    }
    

    
    

}
