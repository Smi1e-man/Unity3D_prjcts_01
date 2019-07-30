using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForEnemy : MonoBehaviour
{
    bool _moveEnemy = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_moveEnemy);
        if (_moveEnemy)
            transform.position = Vector3.MoveTowards(transform.position, Vector3.back * 100f, 5f * Time.deltaTime);
    }

    public void     MoveOff()
    {
        _moveEnemy = false;
    }
}
