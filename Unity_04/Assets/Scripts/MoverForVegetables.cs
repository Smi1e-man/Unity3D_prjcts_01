using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForVegetables : MonoBehaviour
{

    [SerializeField] Animation _anim;

    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animation>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.005f);
        }
    }

    public void     AnimOn()
    {
        _anim.Play();
        _rb.useGravity = true;
    }

}
