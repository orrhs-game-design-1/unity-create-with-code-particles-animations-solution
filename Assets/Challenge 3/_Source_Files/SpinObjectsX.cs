using UnityEngine;

namespace Challenge_3._Source_Files
{
    public class SpinObjectsX : MonoBehaviour
    {
        public float spinSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}