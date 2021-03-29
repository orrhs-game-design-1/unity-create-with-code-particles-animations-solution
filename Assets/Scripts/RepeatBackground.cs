using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float repeatWidth;
    private Vector3 startPos;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) transform.position = startPos;
    }
}