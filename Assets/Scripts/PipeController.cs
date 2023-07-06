using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector2.left);
    }
    public void SetSpeed(float speed)
    {
        this.Speed = speed;
    }
    public void UpSpeed(float speedMultiplier)
    {
        this.Speed += speedMultiplier;
    }
}
