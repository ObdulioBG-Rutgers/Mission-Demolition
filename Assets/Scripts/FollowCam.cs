using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;


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
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = cam_z;
        transform.position = destination;
    }
}
