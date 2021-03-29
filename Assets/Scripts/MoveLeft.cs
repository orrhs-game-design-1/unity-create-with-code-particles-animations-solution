using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const float LeftBound = -15;
    private PlayerController playerControllerScript;
    private const float Speed = 30;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerControllerScript.gameOver == false) transform.Translate(Vector3.left * (Time.deltaTime * Speed));

        if (transform.position.x < LeftBound && gameObject.CompareTag("Obstacle")) Destroy(gameObject);
    }
}