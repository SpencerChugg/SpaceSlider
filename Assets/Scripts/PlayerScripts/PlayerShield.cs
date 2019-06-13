using UnityEngine;
using UnityEngine.UI;

public class PlayerShield : MonoBehaviour
{
    public Image shieldBar;
    public FloatSO pShield;
    public FloatSO pMaxShield;
    public FloatSO pShieldRegen;
    void Update()
    {
        shieldBar.fillAmount = pShield.Value / pMaxShield.Value;
    }
}