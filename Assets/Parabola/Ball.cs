/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform basket;

    public float radian = 1.0f;
    public Vector2 point = new Vector2(0.7f, 1.5f);

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Shoot2(), ForceMode.VelocityChange);
    }
    Vector3 Shoot()
    {
        Vector3 ray = (basket.position - transform.position);
        float distance = new Vector2(ray.x, ray.z).magnitude;
        float height = ray.y;
        float fitting = height / distance + radian * distance;
        float hDistance = fitting / radian / 2;
        float hHeight = -radian * hDistance * hDistance + fitting * hDistance;
        float t = Mathf.Sqrt(hHeight * 2 / -Physics.gravity.y);
        Vector2 velocityXZ = hDistance / t * new Vector2(ray.x, ray.z).normalized;
        float velocityY = -Physics.gravity.y * t;
        return new Vector3(velocityXZ.x, velocityY, velocityXZ.y);
    }
    Vector3 Shoot2()
    {
        Vector3 ray = (basket.position - transform.position);
        float distance = new Vector2(ray.x, ray.z).magnitude;
        float height = ray.y;
        float hDistance = distance * point.x;
        float hHeight = height * point.y;
        float a = (height / distance - hHeight / hDistance) / (hDistance - distance);
        float b = height / distance + a * distance;
        float t = Mathf.Sqrt(hHeight * 2 / -Physics.gravity.y);
        Vector2 velocityXZ = hDistance / t * new Vector2(ray.x, ray.z).normalized;
        float velocityY = -Physics.gravity.y * t;
        return new Vector3(velocityXZ.x, velocityY, velocityXZ.y);
    }
}