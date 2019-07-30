using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject _prefFruit;


    [SerializeField] float _stepTime = 1f;
    float _nextTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _nextTime)
        {
            _nextTime = Time.time + _stepTime;
            Instantiate(_prefFruit, transform.position, Quaternion.identity);
        }
    }
}
