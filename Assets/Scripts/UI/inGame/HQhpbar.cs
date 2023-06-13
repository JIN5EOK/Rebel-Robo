using UnityEngine;
using UnityEngine.UI;

public class HQhpbar : MonoBehaviour
{
    [SerializeField] private PlayerHQ playerHQ;
    [SerializeField] private Slider hpSlider;
    private void OnEnable()
    {
        playerHQ.OnHpChange += (n) => hpSlider.value = n;
    }

    

    
}