using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int maxPlatforms = 20;
    [SerializeField] GameObject platform;
    [SerializeField] private float horizontalMin = 6.5f;
    [SerializeField] private float horizontalMax = 14f;
    [SerializeField] private float verticalMin = -6f;
    [SerializeField] private float verticalMax = 6f;

    private Vector2 originalPosition;

	// Use this for initialization
	void Start ()
    {
        originalPosition = transform.position;
        Spawn();
	}

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originalPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originalPosition = randomPosition;
        }
    }
}
