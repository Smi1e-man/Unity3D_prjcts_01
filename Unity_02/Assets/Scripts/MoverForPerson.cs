using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForPerson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //trampline
            //transform.position = Vector3.MoveTowards(transform.position, Vector3.forward * 100000f, 10f * Time.deltaTime);
            //ramp
            transform.position = Vector3.MoveTowards(transform.position, Vector3.down * 1000000f, 20f * Time.deltaTime);
        }
    }
}
