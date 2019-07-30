using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForWeapon : MonoBehaviour
{

    [SerializeField] GameObject _target;
    [SerializeField] float _impulse = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.GetComponent<MoverForEnemy>())
            collision.gameObject.transform.parent.GetComponent<MoverForEnemy>().MoveOff();
        for (int i = 0; i < collision.gameObject.transform.parent.childCount; i++)
        {
            collision.gameObject.transform.parent.GetChild(i).GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.transform.parent.GetChild(i).GetComponent<Rigidbody>().AddForce(transform.position * _impulse, ForceMode.Impulse);
        }

        //collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.position * _impulse, ForceMode.Impulse);
    }

}
