using UnityEngine;

public class CloudCrafter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int num_clouds = 40;
    public GameObject cloud_prefab;
    public Vector3 cloud_pos_min = new Vector3(-50, -5, 10);
    public Vector3 cloud_pos_max = new Vector3(150, 100, 10);
    public float cloud_scale_min = 1;
    public float cloud_scale_max = 3;
    public float cloud_speed_mult = 0.5f;

    private GameObject[] cloud_instances;

    void Awake()
    {
        cloud_instances = new GameObject[num_clouds];

        GameObject anchor = GameObject.Find("CloudAnchor");

        GameObject cloud;

        for (int i = 0; i < num_clouds; i++)
        {
            cloud = Instantiate<GameObject>(cloud_prefab);

            Vector3 c_pos = Vector3.zero;
            c_pos.x = Random.Range(cloud_pos_min.x, cloud_pos_max.x);
            c_pos.y = Random.Range(cloud_pos_min.y, cloud_pos_max.y);

            float scale_u = Random.value;
            float scale_val = Mathf.Lerp(cloud_scale_min, cloud_scale_max, scale_u);

            c_pos.y = Mathf.Lerp(cloud_pos_min.y, c_pos.y, scale_u);
            c_pos.z = 100 - 90 * scale_val;

            cloud.transform.position = c_pos;
            cloud.transform.localScale = Vector3.one * scale_val;
            cloud.transform.SetParent(anchor.transform);
            cloud_instances[i] = cloud;
        }
    }

    private void Update()
    {
        foreach (GameObject cloud in cloud_instances)
        {
            float scale_val = cloud.transform.localScale.x;
            Vector3 c_pos = cloud.transform.position;

            c_pos.x -= scale_val * Time.deltaTime * cloud_speed_mult;

            if (c_pos.x <= cloud_pos_min.x)
            {
                c_pos.x = cloud_pos_max.x;
            }

            cloud.transform.position = c_pos;
        }
    }
}
