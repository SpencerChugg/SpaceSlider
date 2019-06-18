using UnityEngine;
using UnityEngine.UI;

public class SliderValueChange : MonoBehaviour
{
    public Slider slider;
    public float changeAmount;
    private void OnTriggerEnter2D(Collider2D other)
    {
    slider.value -= changeAmount;
    }
}
