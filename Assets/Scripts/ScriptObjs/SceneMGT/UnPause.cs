using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "SceneManagement/UnPause")]
public class UnPause : ScriptableObject
{
    public void TimeChange()
    {
        Time.timeScale = 1;
    }
}