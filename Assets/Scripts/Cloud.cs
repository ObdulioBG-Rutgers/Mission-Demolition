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

    private void Start()
    {
        spheres = new List<GameObject>();

        int num = Random.Range(num_sphere_min, num_sphere_max);

        for (int i = 0; i < num; i++)
        {
            GameObject sp = Instantiate<GameObject>(cloud_sphere);
            spheres.Add(sp);
            Transform sp_trans = sp.transform;
            sp_trans.SetParent(this.transform);

            Vector3 offset = Random.insideUnitSphere;
            offset.x *= sphere_offset_scale.x;
            offset.y *= sphere_offset_scale.y;
            offset.z = sphere_offset_scale.z;

            sp_trans.localPosition = offset;

            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphere_scale_range_x.x, sphere_scale_range_x.y);
            scale.y = Random.Range(sphere_scale_range_y.x, sphere_scale_range_y.y);
            scale.z = Random.Range(sphere_scale_range_z.x, sphere_scale_range_z.y);

            scale.y *= 1 - (Mathf.Abs(offset.x) / sphere_offset_scale.x);
            scale.y = Mathf.Max(scale.y, scale_y_min);

            sp_trans.localScale = scale;
        }
    }

    private void Update()
    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            Restart();
//        }
    }

    void Restart()
    {
        foreach (GameObject sp in spheres)
        {
            Destroy(sp);
        }

        Start();
    }
}
