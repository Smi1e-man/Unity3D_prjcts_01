using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForCamera : MonoBehaviour
{

    [SerializeField] GameObject _person;

    Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _person.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _person.transform.position + _offset;
    }
}
