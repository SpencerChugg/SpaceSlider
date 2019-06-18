using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 1;
    private float percent = 0;
    private float signOffset;
    public float width = 1f;
    public AnimationCurve speedCurve;

    void Start()
    {
 
    }
    private void Update()
    {
        percent += Time.deltaTime * speed;
        percent = percent % 1;
        float speedCurvePercent = speedCurve.Evaluate(percent);
        signOffset = Mathf.Sin(Time.time) * width;
        Vector3 finalPosition = Vector3.Lerp(point1.position, point2.position, speedCurvePercent);
        finalPosition.x += signOffset;
        transform.position = finalPosition;
    }
}
