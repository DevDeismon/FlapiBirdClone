using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    [SerializeField] private float _spawnRatio;
    [SerializeField] private GameObject _pipesPack;
    [SerializeField] private float _positionX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private float _t;

    public float SpawnRatio
    {
        get { return _spawnRatio; }
        set { _spawnRatio = value; }
    }

    void Start()
    {
        _t = SpawnRatio;
        Instantiate(_pipesPack, new Vector2(_positionX, RandomY()), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    private float RandomY()
    {
        return Random.Range(_minY, _maxY);
    }
    private void Spawn()
    {
        _t -= Time.deltaTime;
        if (_t <= 0)
        {
            Instantiate(_pipesPack, new Vector2(_positionX, RandomY()), Quaternion.identity);
            _t = SpawnRatio;
        }
    }

    public void SetSpawnPipes(float newRatio)
    {
        this.SpawnRatio = newRatio;
    }
    public void ReduceSpawnRatio(float ratioReducer)
    {
        this.SpawnRatio -= ratioReducer;
    }
}
