using UnityEngine;

public class ForwardRotation : MonoBehaviour
{

    private Vector3 oldPos;
    public Vector3 worldUp = Vector3.up;
    public Transform lookAtObject;
    public Vector3 eulerValue;
    public float angle;

    void Update()
    {
        //var direction = (oldPos - transform.position).normalized;
        var direction = GetDirection(oldPos, transform.position);
        transform.rotation = Quaternion.LookRotation(direction);

        Vector3 lookAtPoint = transform.position + direction;



        //Vector3 targetDir = target.position - transform.position;

        // The step size is equal to speed times frame time.
        //float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, direction, 1000, 0.0f);
        //Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        //transform.rotation = Quaternion.LookRotation(newDir);


        transform.rotation = LookAtRotation2D(transform.position, lookAtPoint, 0);





        //Vector3 relativePos = lookAtPoint - transform.position;
        ////transform.LookAt(lookAtPoint, worldUp);
        ////Quaternion rotation = Quaternion.LookRotation(relativePos, worldUp);
        ////Mathf.Rad2Deg
        ////Quaternion.LookRotation()
        //angle = GetAngle(transform.position, lookAtPoint);
        ////transform.rotation = rotation;
        //eulerValue.z = angle;   
        //transform.rotation = Quaternion.Euler(eulerValue);
        lookAtObject.position = lookAtPoint;
        oldPos = transform.position;
    }

    public Quaternion LookAtRotation2D(Transform from, Transform to, float offsetAngle)
    {
        var dir = to.position - from.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle + offsetAngle, Vector3.forward);
    }

    public Quaternion LookAtRotation2D(Vector3 from, Vector3 to, float offsetAngle)
    {
        var dir = to - from;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle + offsetAngle, Vector3.forward);
    }

    float GetAdjacent(Vector2 point1, Vector2 point2)
    {
        return point2.x - point1.x;
    }

    float GetOpposite(Vector2 point1, Vector2 point2)
    {
        return point2.y - point1.y;
    }

    float GetAngle(Vector2 point1, Vector2 point2)
    {
        var adjacent = GetAdjacent(point1, point2);
        var opposite = GetOpposite(point1, point2);
        return Mathf.Rad2Deg * Mathf.Atan(opposite / adjacent);
    }


    Vector3 GetDirection(Vector3 from, Vector3 to)
    {
        var heading = to - from;
        var distance = heading.magnitude;
        var direction = heading / distance;
        return direction.normalized;
    }
}
