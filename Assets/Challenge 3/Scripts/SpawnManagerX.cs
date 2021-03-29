using UnityEngine;

namespace Challenge_3.Scripts
{
    public class SpawnManagerX : MonoBehaviour
    {
        public GameObject[] objectPrefabs;

        private PlayerControllerX playerControllerScript;
        private readonly float spawnDelay = 2;
        private readonly float spawnInterval = 1.5f;

        // Start is called before the first frame update
        private void Start()
        {
            InvokeRepeating(nameof(SpawnObjects), spawnDelay, spawnInterval);
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        }

        // Spawn obstacles
        private void SpawnObjects()
        {
            // Set random spawn location and random object index
            var spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
            var index = Random.Range(0, objectPrefabs.Length);

            // If game is still active, spawn new object
            if (!playerControllerScript.gameOver)
                Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
}