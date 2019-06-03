using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneManagement/SceneNameSO")]
public class SceneName : ScriptableObject
{
    public void LoadbyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
