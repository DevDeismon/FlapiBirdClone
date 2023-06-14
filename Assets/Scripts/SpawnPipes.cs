using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    [SerializeField] private GameObject pipesPack;
    [SerializeField] private float positionX;
    [SerializeField] private float spawnRatio;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private float t;
    void Start()
    {
        t = spawnRatio;
        Instantiate(pipesPack, new Vector2(positionX, RandomY()), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    private float RandomY()
    {
        return Random.Range(minY, maxY);
    }
    private void Spawn()
    {
        t -= Time.deltaTime;
        if (t <= 0)
        {
            Instantiate(pipesPack, new Vector2(positionX, RandomY()), Quaternion.identity);
            t = spawnRatio;
        }
    }

    public void SetSpawnPipes(float newRatio)
    {
        this.spawnRatio = newRatio;
    }
    public float GetspawnPipes()
    {
        return spawnRatio;
    }
}
