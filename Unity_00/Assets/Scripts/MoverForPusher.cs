using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForPusher : MonoBehaviour
{
    //protected
    [SerializeField] GameObject     _centrePushRotate;
    [SerializeField] float          _speedRotate = 300f;

    bool _active = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
            Rotate();
    }

    void    Rotate()
    {
        transform.RotateAround(_centrePushRotate.transform.position, Vector3.back, _speedRotate * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _active = false;
        if (other.GetComponent<MeshRenderer>().material.color == Color.yellow)
        {
            Debug.Log("FAIL");
        }
        else
        {
            GameManager._active = true;
            other.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    other.GetComponent<MeshRenderer>().material.color = Color.red;
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    other.GetComponent<MeshRenderer>().material.color = Color.red;

    //}
}
