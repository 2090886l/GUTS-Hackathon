using UnityEngine;

//This script controls the scrolling of the background
public class scroll : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeX;
	public short direction; //1 for right, -1 for left

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPosition + direction * Vector2.right * newPosition;
    }
}