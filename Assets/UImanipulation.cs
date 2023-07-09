using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanipulation : MonoBehaviour
{

    [SerializeField] private Image DiamondOutline;
    [SerializeField] private Image DiamondFilled;
    [SerializeField] private Image Skull;
    [SerializeField] private TextMeshProUGUI DiamondCounter;
    [SerializeField] private TextMeshProUGUI Avertissment;
    private float show_time = 0;
    private bool text_shown = false;

    public void ShowAvertissment()
    {
        Avertissment.enabled = true;
        text_shown = true;
        show_time = 0;
    }
    private void HideText()
    {
        Avertissment.enabled = false;
        text_shown = false;
        show_time = 0;
    }
    public void Showskull()
    {
        Skull.enabled = true;
        
        show_time = 0;
    }

    public void SetDiamondAmout(int current, int max)
    {
        DiamondFilled.fillAmount = ((float)current) / (float)max;
        DiamondCounter.text = current + " / " + max;
    }
    private void Update()
    {
        if (text_shown)
        {
            show_time += Time.deltaTime;
        }
        if (show_time > 2f)
        {
            HideText();
        }
    }
}
