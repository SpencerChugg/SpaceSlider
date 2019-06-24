using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderValueChange : MonoBehaviour
{
    public Slider shieldSlider;
    public Slider healthSlider;
    public float changeAmount;
    private void OnTriggerEnter2D(Collider2D PlayerCollision)
    {
        if (PlayerCollision.gameObject.tag == "Player")
        {
            if (shieldSlider.value > 0)
            {
                shieldSlider.value -= changeAmount;
            }
            if (shieldSlider.value <= 0)
            {
                healthSlider.value -= changeAmount;
            }
        }
    }
}