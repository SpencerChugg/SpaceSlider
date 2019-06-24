using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarRegeneration : MonoBehaviour
{
    public Slider regenSlider;
    public float regenAmount;
    public float regenSpeed;
    void Update()
    {
        StartCoroutine(WaitTime());
    }
    IEnumerator WaitTime()
    {
        if (regenSlider.value < 1)        
        {
            yield return new WaitForSeconds(regenSpeed);
            regenSlider.value += regenAmount;
        }
        
    }
}

    