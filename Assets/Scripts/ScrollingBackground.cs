using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRend;
    void Start()
    {
    }
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(0f, bgSpeed * Time.deltaTime);
    }
}
