using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private PlayerController playerControllerScript;
    private const float RepeatRate = 2;
    private readonly Vector3 spawnPos = new Vector3(25, .5f, 0);
    private const float StartDelay = 2;

    // Start is called before the first frame updated
    private void Start()
    {
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}