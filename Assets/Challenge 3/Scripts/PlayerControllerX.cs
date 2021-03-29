using UnityEngine;

namespace Challenge_3.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        public bool gameOver;

        public float floatForce;

        public ParticleSystem explosionParticle;
        public ParticleSystem fireworksParticle;
        public AudioClip moneySound;
        public AudioClip explodeSound;
        private const float GravityModifier = 1.5f;
        private bool isLowEnough = true;

        private AudioSource playerAudio;
        private Rigidbody playerRb;
        private const float YBottomLimit = 0;
        private const float YTopLimit = 12;


        // Start is called before the first frame update
        private void Start()
        {
            Physics.gravity *= GravityModifier;
            playerAudio = GetComponent<AudioSource>();

            // Apply a small upward force at the start of the game

            playerRb = GetComponent<Rigidbody>();
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        // Update is called once per frame
        private void Update()
        {
            // Check player position is low enough
            isLowEnough = transform.position.y < YTopLimit;
            if (transform.position.y < YBottomLimit) playerRb.AddForce(Vector3.up * floatForce);
            // While space is pressed and player is low enough, float up
            if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough) playerRb.AddForce(Vector3.up * floatForce);
        }

        private void OnCollisionEnter(Collision other)
        {
            // if player collides with bomb, explode and set gameOver to true
            if (other.gameObject.CompareTag("Bomb"))
            {
                explosionParticle.Play();
                playerAudio.PlayOneShot(explodeSound, 1.0f);
                gameOver = true;
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
            }

            // if player collides with money, fireworks
            else if (other.gameObject.CompareTag("Money"))
            {
                fireworksParticle.Play();
                playerAudio.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);
            }
        }
    }
}