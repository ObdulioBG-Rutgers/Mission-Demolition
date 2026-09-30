using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefab_projectile;
    public float velocity_mult = 8f;

    [Header("Set Dynamically")]
    public GameObject launch_point;
    public Vector3 launch_pos;
    public GameObject projectile;
    public bool aiming_mode;
    
    private Rigidbody projectile_rigid_body;


    private void Awake()
    {
        Transform launch_point_trans = transform.Find("LaunchPoint");
        launch_point = launch_point_trans.gameObject;
        launch_point.SetActive(false);

        launch_pos = launch_point_trans.position;
    }

    private void Update()
    {
        if (!aiming_mode) return;

        Vector3 mouse_pos_2d = Input.mousePosition;
        mouse_pos_2d.z = -Camera.main.transform.position.z;
        Vector3 mouse_pos_3d = Camera.main.ScreenToWorldPoint(mouse_pos_2d);

        Vector3 mouse_delta = mouse_pos_3d - launch_pos;
        float max_magnitude = this.GetComponent<SphereCollider>().radius;

        if (mouse_delta.magnitude > max_magnitude)
        {
            mouse_delta.Normalize();
            mouse_delta *= max_magnitude;
        }

        Vector3 projectile_pos = launch_pos + mouse_delta;
        projectile.transform.position = projectile_pos;

        if (Input.GetMouseButtonUp(0))
        {
            aiming_mode = false;
            projectile_rigid_body.isKinematic = false;
            projectile_rigid_body.linearVelocity = -mouse_delta * velocity_mult;
            FollowCam.POI = projectile;
            projectile = null;
        }
    }

    void OnMouseEnter()
    {
        //print("Slingshot: OnMouseEnter()");

        launch_point.SetActive(true);
    }

    void OnMouseExit()
    {
        //print("Slingshot: OnMouseExit()");

        launch_point.SetActive(false);
    }

    private void OnMouseDown()
    {
        aiming_mode = true;

        projectile = Instantiate(prefab_projectile) as GameObject;
        projectile.transform.position = launch_pos;
        projectile_rigid_body = projectile.GetComponent<Rigidbody>();
        projectile_rigid_body.isKinematic = true;
    }
}
