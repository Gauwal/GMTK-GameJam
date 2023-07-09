using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanipulation : MonoBehaviour
{

    [SerializeField] private Image DiamondOutline;
    [SerializeField] private Image DiamondFilled;
    [SerializeField] private TextMeshProUGUI DiamondCounter;

    public void SetDiamondAmout(int current, int max)
    {
        DiamondFilled.fillAmount = ((float)current) / (float)max;
        DiamondCounter.text = current + " / " + max;
    }
}
