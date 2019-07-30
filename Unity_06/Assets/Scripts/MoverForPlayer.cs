using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForPlayer : MonoBehaviour
{
    //private visible
    [SerializeField, Range(0.0f, 360.0f)]
    private float _angle = 60f;

    [SerializeField, Range(0.0f, 360.0f)]
    private float _angleNew = 60f;

    [SerializeField, Range(0.0f, 5.0f)]
    private float _speedPendulum = 2f;

    [SerializeField, Range(0.0f, 10.0f)]
    private float _startTime = 0.0f;

    [SerializeField]
    GameObject _target;

    [SerializeField]
    private float _speedMove = 2f;


    //private
    Quaternion _start, _end;

    Rigidbody _rb;

    bool _moveActive = false;
    bool _moveLeft = true;
    bool _moveRight = false;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _start = PendulumRotation(_angle);
        _end = PendulumRotation(-_angle);
    }

    private void FixedUpdate()
    {
        _startTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles += new Vector3(0f, 0f, 0.5f);
            if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 65)
            {
                _moveRight = false;
                _moveLeft = true;
            }
            //_end = _start;
            //_start = transform.rotation;
            Debug.Log("Left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles -= new Vector3(0f, 0f, 0.5f);
            if (transform.eulerAngles.z > 300 && transform.eulerAngles.z < 360)
            {
                _moveRight = true;
                _moveLeft = false;
            }
            //_start = transform.rotation;
            Debug.Log("Right");
        }
        else
        {
            //// Lerp Pendulum
                //transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speedPendulum + Mathf.PI / 2f) + 1f) / 2f);

            //// another Pendulum
            if (transform.eulerAngles.z >= 60 && transform.eulerAngles.z < 65)
            {
                _rb.useGravity = true;
                _moveActive = false;
                //_moveLeft = false;
                //_moveRight = true;
            }
            if (transform.eulerAngles.z <= 300 && transform.eulerAngles.z > 295)
            {
                _rb.useGravity = true;
                _moveActive = false;
                //_moveLeft = true;
                //_moveRight = false;
            }

            if (_moveRight)
            {
                if ((transform.eulerAngles.z > 50 && transform.eulerAngles.z < 60) ||
                    (transform.eulerAngles.z > 300 && transform.eulerAngles.z < 310))
                    transform.eulerAngles -= new Vector3(0f, 0f, 0.2f);
                else
                    transform.eulerAngles -= new Vector3(0f, 0f, 0.5f);
            }
            if (_moveLeft)
            {
                if ((transform.eulerAngles.z > 300 && transform.eulerAngles.z < 310) ||
                    (transform.eulerAngles.z > 50 && transform.eulerAngles.z < 60))
                    transform.eulerAngles += new Vector3(0f, 0f, 0.2f);
                else
                    transform.eulerAngles += new Vector3(0f, 0f, 0.5f);
            }
        }
        //Debug.Log(transform.rotation.z);
        //Debug.Log(transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            //_start = PendulumRotation(_angleNew);
            //_end = PendulumRotation(-(_angleNew));
            //_speedPendulum = 0.5f;
            _moveActive = true;
        }

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.eulerAngles += new Vector3(0f, 0f, 1f);
        //    Debug.Log("Left");
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    Debug.Log("Right");
        //}

        if (_moveActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speedMove * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speedPendulum + Mathf.PI / 2f) + 1f) / 2f);
        }
    }

    Quaternion PendulumRotation(float angle)
    {
        var pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + angle;

        if (angleZ > 180)
            angleZ -= 360;
        else if (angleZ < -180)
            angleZ += 360;
        //Debug.Log(angleZ);

        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);

        return pendulumRotation;

    }
}
