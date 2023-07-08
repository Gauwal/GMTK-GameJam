using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   
    [SerializeField] private Image emptyhealth;
    [SerializeField] private Image currenthealth;

    private void Start()
    {
        
    }

    private void Update()
    {
        currenthealth.fillAmount = 0.2f + 0.8f;
    }
}
