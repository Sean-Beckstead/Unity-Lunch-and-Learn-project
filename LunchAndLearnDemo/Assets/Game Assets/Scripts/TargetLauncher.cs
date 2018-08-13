using UnityEngine;
using System.Collections;

public class TargetLauncher : MonoBehaviour
{

    public GameObject TargetPrefab;
    public bool IsSpawning = false;
    public int NumberToSpawn = 3;
    public int AmountSpawned = 0;
    public float SpawnCooldown = 10f;
    public float SpawnTimer = 0f;
    public Vector3 LaunchForce = new Vector3(-5f, 10f, 2f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpawning)
        {
            SpawnTimer += Time.deltaTime;
            if (SpawnTimer >= SpawnCooldown)
            {
                SpawnTarget();
                if (AmountSpawned >= NumberToSpawn)
                {
                    ResetLauncher();
                }
            }
        }
    }

    public void LaunchTargets()
    {
        IsSpawning = true;
        SpawnTimer = SpawnCooldown;
        Debug.Log("Is Launching!");
    }

    void ResetLauncher()
    {
        IsSpawning = false;
        SpawnTimer = 0f;
        AmountSpawned = 0;
    }

    void SpawnTarget()
    {
        GameObject newTarget = Instantiate(TargetPrefab, gameObject.transform);
        newTarget.GetComponent<Rigidbody>().AddForce(LaunchForce);
        AmountSpawned++;
        SpawnTimer = 0f;
    }
}
