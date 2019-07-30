using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorPendulumForKnife : MonoBehaviour
{
    //private visible
    [SerializeField, Range(0.0f, 360.0f)]
    private float _angle = 60f;

    [SerializeField, Range(0.0f, 5.0f)]
    private float _speed = 2f;

    [SerializeField, Range(0.0f, 10.0f)]
    private float _startTime = 1.0f;


    //private
    Quaternion _start, _end;



    // Start is called before the first frame update
    void Start()
    {
        _start = PendulumRotation(_angle);
        _end = PendulumRotation(-_angle);
    }

    private void FixedUpdate()
    {
        _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2f) + 1f) / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Quaternion  PendulumRotation(float angle)
    {
        var pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + angle;

        if (angleZ > 180)
            angleZ -= 360;
        else if (angleZ < -180)
            angleZ += 360;

        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);

        return pendulumRotation;

    }

}
