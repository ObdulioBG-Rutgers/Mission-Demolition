using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 min_xy = Vector2.zero;


    [Header("Set Dynamically")]
    public float cam_z;

    void Awake()
    {
        cam_z = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        if (POI == null) return;

        Vector3 destination = POI.transform.position;
        destination.x = Mathf.Max(min_xy.x, destination.x);
        destination.y = Mathf.Max(min_xy.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = cam_z;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
    }
}
