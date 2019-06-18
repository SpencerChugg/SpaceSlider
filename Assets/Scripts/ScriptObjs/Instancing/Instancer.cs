using UnityEngine;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject Prefab;

    public void InstanceObjAtBehavior(Transform location)
    {
        Instantiate(Prefab, location.position, Quaternion.identity);
    }
}
