using UnityEngine;
using System.Collections.Generic;

public class Cloud : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject cloud_sphere;
    public int num_sphere_min = 6;
    public int num_sphere_max = 10;
    public Vector3 sphere_offset_scale = new Vector3(5, 2, 1);
    public Vector2 sphere_scale_range_x = new Vector2(4, 8);
    public Vector2 sphere_scale_range_y = new Vector2(3, 4);

    public Vector2 sphere_scale_range_z = new Vector2(2, 4);

    public float scale_y_min = 2f;

    private List<GameObject> spheres;
}
